using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Motor : MonoBehaviour, IMotor
{
    [Header("Movement Settings")]
    [SerializeField] protected CharacterController characterController;
    [SerializeField] protected GameObject driver;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float gravity;
    protected Vector2 velocity;

    private void Awake()
    {
        OnAwake();
    }
    private void Update()
    {
        OnUpdate();
    }

    public abstract void Move();

    protected virtual void OnAwake()
    {
        if (characterController == null)
        {
            if (gameObject.TryGetComponent<CharacterController>(out CharacterController c))
            {
                characterController = c;
            }
            else
            {
                Debug.LogError("Critical variable unassigned in " + gameObject.name);
                return;
            }
        }
       
        if (driver == null)
        {
            Debug.LogError("Critical variable unassigned in " + gameObject.name);
            return;
        } else
        {
            //TBD
        }
    }
    protected virtual void OnUpdate()
    {
        Move();
    }

}
