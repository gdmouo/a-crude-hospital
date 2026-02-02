using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tap : Interactible
{
    public override void Interact(Character character)
    {
        OnInteract(OnInteractEventFinished);
    }
    public virtual void OnInteractEventFinished()
    {

    }

    protected virtual void OnInteract(Action a)
    {

    }
}
