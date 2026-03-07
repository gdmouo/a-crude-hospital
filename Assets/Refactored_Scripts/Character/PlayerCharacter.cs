using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField] private PlayerBackpack playerBackpack;
    private Pickup itemHolding = null;
    public static PlayerCharacter Instance { get; private set; }
    public Pickup ItemHolding { get { return itemHolding; } }

    protected override void OnAwake()
    {
        base.OnAwake();
        Instance = this;
        if (playerBackpack == null)
        {
            Debug.LogError("Critical variable unassigned in: " + gameObject.name);  
        }
    }
    public override CharacterType GetCharacterType()
    {
        return CharacterType.Player;
    }

    public Interactible GetSelectedInteractible()
    {
        if (sensor != null)
        {
            return (sensor as PlayerSensor).SelectedInteractible;
        }
        return null;
    }

    public void InteractWithItemSelected()
    {
        Interactible i = GetSelectedInteractible();
        if (i != null)
        {
            i.Interact(this);
        }
    }
    public PlayerBackpack GetPlayerBackpack()
    {
        return playerBackpack;
    }

    //requires: pickup is from hotbar
    public void HoldItem(Pickup pickup)
    {
        if (itemHolding != null)
        {
            //
            DropItem(itemHolding);
        }

        itemHolding = pickup;
        // pickup.TogglePhysical(true);
        pickup.Hold();

    }

    public void DropItem(Pickup pickup)
    {
        itemHolding = null;
        // pickup.TogglePhysical(true);
        pickup.Store();

    }
    //pickup funciton
}
