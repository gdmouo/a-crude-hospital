using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterSensor : MonoBehaviour, ICharacterSensor
{
    protected Character character;

    private void Awake()
    {
        OnAwake();
    }

    private void Start()
    {
        OnStart();
    }

    void Update()
    {
        RaycastSense();
    }

    public virtual void Init(Character c)
    {
        character = c;
    }

    public virtual void CharacterTriggerFunction(Collider other)
    {
        if (other.gameObject.TryGetComponent<PassThrough>(out PassThrough b))
        {
            if (character != null)
            {
                b.Interact(character);
            }
        }
    }

    protected abstract void RaycastSense();

    protected virtual void OnAwake()
    {

    }

    protected virtual void OnStart()
    {

    }
}
