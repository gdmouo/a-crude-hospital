using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoopStep
{
    public bool UpdateFunction();
}


public enum LoopStepResult
{
    BeatBoxFound,
    BeatBoxNotFound,
    Killed,
    LoopsCompleted,
    StillCounting
}

public enum LoopStepLabel
{
    Hide,
    Seek,
    FinishAllLoops,
    PlayerPickedUpBB,
    PlayerDeath,
    ERROR_OCCURED
}


