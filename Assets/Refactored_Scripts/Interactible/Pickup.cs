using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Pickup : Interactible
{
    [SerializeField] protected PickupUISO pickupUISO;
    [SerializeField] protected PickupType pickupType;
    public PickupType Type {  get { return pickupType; } }
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
                SetPhysical(p.GetHotbarHidePar());
                pickedUp = true;
                OnPickup();
            }
        }
    }

    public void AutoSetInInventory()
    {
        if (pickedUp)
        {
            return;
        }

        PlayerCharacter player = PlayerCharacter.Instance;
        PlayerBackpack p = player.GetPlayerBackpack();
        if (p.TryInsertItem(this))
        {
            SetPhysical(p.GetHotbarHidePar());
            pickedUp = true;
            OnPickup();
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

    private void SetPhysical(Transform parent)
    {
        SetParentToFollow(parent);
        transform.position = parent.position;
        gameObject.SetActive(false);
    }
}

public enum PickupType
{
    Default,
    Pillcase
}
