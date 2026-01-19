using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayGameTrigger : Triggerable
{
    public override void Interact(Player player)
    {
        HallwayGameManager.Instance.BeginGame();
    }
}
