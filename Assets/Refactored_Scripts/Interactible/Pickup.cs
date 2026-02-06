using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactible
{
    [SerializeField] protected PickupUISO pickupUISO;
    protected bool pickedUp = false;
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
                SetParentToFollow(p.GetHotbarHidePar());
                gameObject.SetActive(false);
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
}
