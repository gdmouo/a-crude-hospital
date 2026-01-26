using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBoxTrigger : PassThrough
{
    public override void Interact(Character character)
    {

    }
    /*
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
    }*/
}
