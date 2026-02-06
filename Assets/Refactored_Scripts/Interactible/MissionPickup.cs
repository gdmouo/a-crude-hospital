using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPickup : Pickup
{
    [SerializeField] private MissionPickupID triggerID;

    //make it so it can only be picekd up after the other styff has ebjfwhaklchz.x, cl;ewkflefuoeli
    protected override void OnPickup()
    {
        string s = triggerID.ToString();
        MissionEvents.RaisePickupCollected(s);
    }
}

public enum MissionPickupID {
    KeycardPickup
}
