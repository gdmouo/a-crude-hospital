using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardDoor : Tap
{
    [SerializeField] private GameObject doorPanel;
    //focus on trivial case first, experiment
    private bool unlocked = false;
    private bool closed = true;

    public bool Unlocked { get { return unlocked; } }

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
        if (unlocked)
        {
            if (closed)
            {
                OpenDoor();
                //open
            } else
            {
                CloseDoor();
                //close
            }
        }
    }

    public void UnlockDoor()
    {
        if (unlocked)
        {
            return;
        }
        unlocked = true;
    }

    public void OpenDoor()
    {
        doorPanel.SetActive(false);
        closed = false;
    }

    public void CloseDoor()
    {
        doorPanel.SetActive(true);
        closed = true;
    }

}
