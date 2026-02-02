using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : Interactible
{
    private const float X_OFFSET = 0.8729f;
    //private bool toggle = false;

    public override void Interact(Character character)
    {
        throw new System.NotImplementedException();
    }

    /*
    public override void Interact(Player player)
    {
        toggle = !toggle;

        //if toggled open
        if (toggle)
        {
            Vector3 offset = new(X_OFFSET, 0f, 0f);
            transform.localPosition += offset;
            //open drawer
        } else
        {
            Vector3 offset = new(X_OFFSET, 0f, 0f);
            transform.localPosition -= offset;
            //if toggled to close
            //close drawer
        }
    }*/
}
