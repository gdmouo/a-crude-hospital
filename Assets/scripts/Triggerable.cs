using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour, IInteractible
{
    [SerializeField] protected InteractibleSO interactibleSO;

    public virtual void Interact(Character character)
    {
    }

    public string GetName()
    {
        return interactibleSO.name;
    }
}
