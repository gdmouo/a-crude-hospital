using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeycardDoorPad : PassThrough
{
    [SerializeField] private Pickup keyCard;
    [SerializeField] private KeycardDoor door;
    [SerializeField] private GameObject padObject;

    //^? nother way? maybe like serial number
    public override void Interact(Character character)
    {
        PlayerCharacter playerCharacter = character as PlayerCharacter;
        if (playerCharacter.ItemHolding != null)
        {
            if (playerCharacter.ItemHolding == keyCard)
            {
                //vunlock door
                if (!door.Unlocked)
                {
                    padObject.GetComponent<Renderer>().material.color = Color.green;
                    door.UnlockDoor();
                }
            }
        }
        //if (character.)
    }
}
