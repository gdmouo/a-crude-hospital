using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactible
{
    [SerializeField] protected PickupUISO pickupUISO;
    protected bool pickedUp = false;
    private bool isHeld = false;
    private int slotNumber = -1;

    public bool IsHeld { get { return isHeld; } }

    public int SlotNumber { get { return slotNumber; } }    
    public override void Interact(Character character)
    {
        if (pickedUp)
        {
            return;
        }
        if (character.GetCharacterType() == CharacterType.Player)
        {
            PlayerCharacter player = character as PlayerCharacter;
            PlayerBackpack p = player.GetPlayerBackpack();
            if (p.TryInsertItem(this))
            {
                //
                SetPhysical(p.GetHotbarHidePar());
               // SetParentToFollow(p.GetHotbarHidePar());
               // gameObject.SetActive(false);
                //
                pickedUp = true;
                OnPickup();
                //uyayauayayayyayayyayay YUPDATE BTIH
            }
        }
    }
    protected void SetParentToFollow(Transform t)
    {
        transform.parent = t;
        transform.localPosition = Vector3.zero;
    }

    protected virtual void OnPickup()
    {

    }

    public PickupUISO GetUISO()
    {
        return pickupUISO;
    }

   // public void Toggle
   /*
    public void TogglePhysical(bool op)
    {
        gameObject.SetActive(op);
        isHeld = true;
    }*/

    public void Hold()
    {
        gameObject.SetActive(true);
        isHeld = true;
    }

    public void Store()
    {
        gameObject.SetActive(false);
        isHeld = false;
    }

    public void SetSlotNumber(int s)
    {
        slotNumber = s;
    }

    //set pos, gameobject false?

    private void SetPhysical(Transform parent)
    {
        SetParentToFollow(parent);
        transform.position = parent.position;
        gameObject.SetActive(false);
    }
}
