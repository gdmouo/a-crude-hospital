using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPassThrough : PassThrough
{
    [SerializeField] private MissionPassThroughID triggerID;
    public override void Interact(Character character)
    {
        string s = triggerID.ToString();
        MissionEvents.RaisePassThroughTriggered(s);
    }
}

public enum MissionPassThroughID
{
    LeftBathroomTrigger,
    LeftRoomTrigger
}