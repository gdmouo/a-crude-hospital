using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LoopStepOperator : ILoopStepOperator
{
    protected LoopStep loopStep;
    public LoopStepOperator(LoopStep l)
    {
        this.loopStep = l;
    }
    public abstract LoopStepLabel GetNextStep();

    public virtual void Meantime()
    {
        if (HallwayGameCanvasManager.Instance != null)
        {
            HallwayGameCanvasManager.Instance.Activate();
            HallwayGameCanvasManager.Instance.SetStepText(loopStep.StepLabel.ToString());
            HallwayGameCanvasManager.Instance.SetTimerText(loopStep.CurrTime.ToString());
        }
    }
}

public class HideStep : LoopStepOperator
{
    public HideStep(LoopStep l) : base(l)
    {
    }
    public override LoopStepLabel GetNextStep()
    {
        
        return LoopStepLabel.Seek;
    }

    public override void Meantime()
    {
        base.Meantime();
    }
}

public class SeekStep : LoopStepOperator
{
    private bool initialHMActivate = false;
    private bool gotPlayerRoom = false;
    private int playerRoom = -1;
    private bool hatmanSent = false;
    private bool setBack = false;
   // private HatmanRoomSelector hatmanRoomSelector;
    public SeekStep(LoopStep l) : base(l)
    {
    }

    public override LoopStepLabel GetNextStep()
    {
        if (PlayerHasBattleBox())
        {
            return LoopStepLabel.PlayerPickedUpBB;
        } else
        {
            if (PlayerWithHatman())
            {
                return LoopStepLabel.PlayerDeath;
            } else
            {
                if (StepIsEndIndex())
                {
                    return LoopStepLabel.FinishAllLoops;
                }
                else
                {
                    return LoopStepLabel.Hide;
                }
            }
        }
    }

    public override void Meantime()
    {
        base.Meantime();
        if (!gotPlayerRoom)
        {
            gotPlayerRoom = true;
            playerRoom = HallwayManager.Instance.GetPlayerRoomIndex();
          //  Debug.Log("Player is in room: " + playerRoom);
        }
        if (!initialHMActivate)
        {
            initialHMActivate = true;
            if (!Hatman.Instance.Activated)
            {
                Hatman.Instance.Activate();
            }
        }
        if (!hatmanSent)
        {
             SendHatman();
        }
        if (loopStep.CurrTime >= loopStep.TimerMax - 1f && !setBack)
        {
            setBack = true;
            Hatman.Instance.SetBackToHallwayStartPos();
        }
    }

    private bool PlayerWithHatman()
    {
        return playerRoom == HallwayManager.Instance.HatmanRoom;
    }

    private bool StepIsEndIndex()
    {
        HallwayGameManager hgm = HallwayGameManager.Instance;
        return hgm.LoopIndex == hgm.LoopMax;
    }

    private bool PlayerHasBattleBox()
    {
        return Player.Instance.Inventory.CheckForBattleBox();
    }

    private int ChooseRoomForHatman()
    {
        HallwayGameManager hgm = HallwayGameManager.Instance;
        HallwayManager hm = HallwayManager.Instance;
        
        return HatmanRoomSelector.Instance.SelectHatmanRoom(hm.PlayerPrevRoom, hgm.LoopIndex);
    }
    
    private void SendHatman()
    {
        int hatmanRoomChoice = ChooseRoomForHatman();
        //
        HallwayManager.Instance.UpdateHatmanRoom(hatmanRoomChoice);
        //why si it giving the wrong location??????
        Vector3 locToGo = HallwayManager.Instance.GetRoomPos(hatmanRoomChoice);
        //HallwayManager.Instance.RoomDictionary[hatmanRoomChoice].gameObject.transform.position;
        //  Debug.Log()
        Hatman.Instance.SetDest(locToGo);
        Debug.Log(locToGo.ToString());
        Hatman.Instance.StartPath();
        hatmanSent = true;
    }

     
}
public class ConcludeRoundStep : LoopStepOperator
{
    //private bool resultsCalculated = false;
    public ConcludeRoundStep(LoopStep l) : base(l)
    {
    }
    public override LoopStepLabel GetNextStep()
    {
        HallwayGameManager.Instance.IncLoopMax();
        if (Player.Instance.Inventory.CheckForBattleBox())
        {
            //hm
            return LoopStepLabel.PlayerPickedUpBB;
            //start sequence for battle
        }
        else
        {
            //lose
            return LoopStepLabel.PlayerDeath;
        }
    }

    public override void Meantime()
    {
        base.Meantime();
    }
}


public class BBStep : LoopStepOperator
{
    private bool battleTriggered = false;
    public BBStep(LoopStep l) : base(l)
    {
    }
    public override LoopStepLabel GetNextStep()
    {
        throw new System.Exception();
    }

    public override void Meantime()
    {
        base.Meantime();
        if (!battleTriggered)
        {
            battleTriggered = true;
            BattleBox.Instance.TriggerBattle();
        }
    }
}

public class DeathStep : LoopStepOperator
{
    public DeathStep(LoopStep l) : base(l)
    {
    }
    public override LoopStepLabel GetNextStep()
    {
        throw new System.Exception();
    }

    public override void Meantime()
    {
        base.Meantime();
        UniverseManager.Instance.GoToDeath();
    }
}

