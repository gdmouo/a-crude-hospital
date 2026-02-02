using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, ICharacter
{
    [SerializeField] protected CharacterMotor motor;
    [SerializeField] protected CharacterSensor sensor;

    private void Awake()
    {
        OnAwake();
    }

    private void Start()
    {
        OnStart();
    }
    public abstract CharacterType GetCharacterType();

    protected virtual void OnAwake()
    {
        motor = GetComponent<CharacterMotor>();
        sensor = GetComponent<CharacterSensor>();

        if (motor == null || sensor == null)
        {
            Debug.LogError("Critical variable unassigned in: " + gameObject.name);
        }
    }

    protected virtual void OnStart()
    {
        sensor.Init(this);
    }

    /*
    public virtual Interactible GetInteractibleSelected()
    {

    }*/
    // public abstract void CharacterTriggerFunction(Collider other);

    /*
    private void OnTriggerEnter(Collider other)
    {
        CharacterTriggerFunction(other);
    }*/
}
