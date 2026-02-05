using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTap : Tap
{
    [SerializeField] protected MissionTapID triggerID;
    protected bool interacted = false;

    public override void OnInteractEventFinished()
    {
        interacted = true;
        string s = triggerID.ToString();
        MissionEvents.RaiseTapEventFinished(s);
    }

    protected override void OnInteract(Action a)
    {
        //ie, trigger maeby dialogue, pass a in, once maeby dialogue is over, it should call a
    }
}

public enum MissionTapID
{
    TalkedToMaebyEvent
} 