using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopStep : ILoopStep
{
    private float timerMax;
    private float timer = 0;
    private LoopStepOperator loopStepOperator;
    public LoopStepLabel StepLabel { get; private set; }
    public float CurrTime {  get {  return timer; } }
    public float TimerMax { get { return timerMax; } }
    public LoopStep(float t, LoopStepLabel l)
    {
        if (HallwayGameManager.Instance != null)
        {
            HallwayGameManager.Instance.IncLoopCount();
        }
        timerMax = t;
        StepLabel = l;
        loopStepOperator = LSOFactory(l); 
    }
    public bool UpdateFunction()
    {
        if (!Timer())
        {
            return Meantime();
        } else
        {
            return true;
        }
    }

    private bool Timer()
    {
        if (timer < timerMax)
        {
            timer += Time.deltaTime;
            return false;
        } else
        {
            return true;
        }
    }

    public LoopStepLabel GetNextStep()
    {
        if (loopStepOperator != null)
        {
            return loopStepOperator.GetNextStep();
        }
        return LoopStepLabel.ERROR_OCCURED;
    }

    private bool Meantime()
    {
        if (loopStepOperator != null)
        {
            return loopStepOperator.Meantime();
        }
        return true;
    }

    private LoopStepOperator LSOFactory(LoopStepLabel l)
    {
        switch (l) {
            case LoopStepLabel.Hide:
                return new HideStep(this);
            case LoopStepLabel.Seek:
                return new SeekStep(this);
            case LoopStepLabel.FinishAllLoops:
                return new ConcludeRoundStep(this);
            case LoopStepLabel.PlayerPickedUpBB:
                return new BBStep(this);
            case LoopStepLabel.PlayerDeath:
                return new DeathStep(this);
            default:
                return null;
        }
    }
}

public class LoopStepFactory {
    private const float HIDE_TIMER = 5f;
    private const float SEEK_TIMER = 10f;
    private const float END_TIMER = 5f;
    private const float BB_TIMER = 5f;
    private const float DEATH_TIMER = 30f;
    private LoopStepLabel lsl;

    public LoopStepFactory(LoopStepLabel l)
    {
        lsl = l;
    }

    public LoopStep GetLoopStep()
    {
        float loopTimer = GetLoopTimer(lsl);
        return new LoopStep(loopTimer, lsl);
    }
    private float GetLoopTimer(LoopStepLabel l)
    {
        switch (l)
        {
            case LoopStepLabel.Hide:
                return HIDE_TIMER;
            case LoopStepLabel.Seek:
                return SEEK_TIMER;
            case LoopStepLabel.FinishAllLoops:
                return END_TIMER;
            case LoopStepLabel.PlayerPickedUpBB:
                return BB_TIMER;
            case LoopStepLabel.PlayerDeath:
                return DEATH_TIMER;
            default:
                return 0f;
        }
    }
}



