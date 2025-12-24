using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBox : Item
{
    public override void Interact(Player player)
    {
        player.StoreItem(this);
    }
    public override void InteractHolding(Player player)
    {
        // Debug.Log("battle");
        BattleMechanicManager.Instance.GoToBeatRoom();
    }
}
