using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardPad : PassThrough
{
    [SerializeField] private Pickup keyCard;

    //^? nother way? maybe like serial number
    public override void Interact(Character character)
    {
        PlayerCharacter playerCharacter = character as PlayerCharacter;
        if (playerCharacter.ItemHolding != null)
        {
            if (playerCharacter.ItemHolding == keyCard)
            {
                ToCall();
            }
        }
        //if (character.)
    }

    private void ToCall()
    {
        //unlock door
    }
}
