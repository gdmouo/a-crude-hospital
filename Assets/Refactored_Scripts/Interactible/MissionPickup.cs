using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPickup : Pickup
{
    [SerializeField] private MissionPickupID triggerID;
    protected override void OnPickup()
    {
        string s = triggerID.ToString();
        MissionEvents.RaisePickupCollected(s);
    }
}

public enum MissionPickupID {
    KeycardPickup
}
