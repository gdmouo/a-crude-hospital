using System;
using UnityEngine;

public class BeatBoxMissionPseudoPickup : MissionTap
{

    protected override void OnInteract(Action a)
    {
        OnInteractEventFinished();
        Destroy(gameObject);
    }

    /*
    public override string GetName()
    {
        return 
    }*/
}
