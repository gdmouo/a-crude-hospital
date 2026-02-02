using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour, IInteractible
{
    public abstract void Interact(Character character);
    public virtual string GetName()
    {
        return gameObject.name;
    }

    /*
    public void SetParentToFollow(Transform t)
    {
        transform.parent = t;
        transform.localPosition = Vector3.zero;
    }*/

    /*
    public InteractibleSO GetInteractibleSO()
    {
        return interactibleSO;
    }*/

}
