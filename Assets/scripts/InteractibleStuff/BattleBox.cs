using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBox : Item
{
    public static BattleBox Instance;

    private void Awake()
    {
        Instance = this;
    }
    public override void Interact(Player player)
    {
        player.StoreItem(this);
    }
    public override void InteractHolding(Player player)
    {
        // Debug.Log("battle");
        //BattleMechanicManager.Instance.GoToBeatRoom();
        BattleMechanicScreen.Instance.Toggle();
    }

    public void TriggerBattle()
    {
        //BattleMechanicManager.Instance.GoToBeatRoom();
        UniverseManager.Instance.GoToBeatRoom();
    }


}
