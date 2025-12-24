using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour, IInteractible
{
    [SerializeField] protected InteractibleSO interactibleSO;

    public virtual void Interact(Player player)
    {
    }

    public string GetName()
    {
        return interactibleSO.interactibleName;
    }

    public string GetHighlight()
    {
        return interactibleSO.interactingHighlight;
    }

    public void SetParentToFollow(Transform t)
    {
        transform.parent = t;
        transform.localPosition = Vector3.zero;
    }

    public InteractibleSO GetInteractibleSO()
    {
        return interactibleSO;
    }

}
