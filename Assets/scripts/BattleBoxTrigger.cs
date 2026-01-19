using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBoxTrigger : Triggerable
{
    public override void Interact(Player player)
    {
        Debug.Log("hoi");
        if (player.Inventory != null && player.Inventory.CheckForBattleBox())
        {
            BattleBox.Instance.TriggerBattle();
        } else
        {
            UniverseManager.Instance.GoToDeath();
        }
    }
}
