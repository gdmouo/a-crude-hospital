using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardDoor : Tap
{
    //unlocked
    //opened

    public override void Interact(Character character)
    {
        OnInteract(OnInteractEventFinished);
    }
    public override void OnInteractEventFinished()
    {

    }

    protected override void OnInteract(Action a)
    {

    }
}
