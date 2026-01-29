using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : Motor
{
    [Header("PlayerMotor Exclusive Fields")]
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float clampAngle = 80f;

    private PlayerInput playerInput = null;

    protected override void OnUpdate()
    {
        base.OnUpdate();
        Rotate();
    }

    public override void Move()
    {
        if (playerInput == null)
        {
            playerInput = GetPlayerDriver(driver);
        }
        if (playerInput.MapEnabled)
        {
            Vector2 inputVector = playerInput.GetMovementVectorNormalized();
            Vector3 moveDirection = transform.right * inputVector.x + transform.forward * inputVector.y;
            characterController.Move(moveSpeed * Time.deltaTime * moveDirection);
        }
    }
    private void Rotate()
    {
        if (playerInput == null)
        {
            return;
        }
        if (playerInput.MapEnabled)
        {
            Vector3 inputVector = playerInput.GetRotationVector();
            transform.Rotate(Vector3.up, inputVector.x * sensitivity * Time.deltaTime, Space.World);
            inputVector.y = Mathf.Clamp(inputVector.y, -clampAngle, clampAngle);
            transform.Rotate(Vector3.right, -inputVector.y * sensitivity * Time.deltaTime, Space.Self);
            transform.eulerAngles = new(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        }
    }

    private PlayerInput GetPlayerDriver(GameObject g)
    {
        if (g.TryGetComponent<PlayerInput>(out PlayerInput p))
        {
            return p;
        } else
        {
            Debug.LogError("Critical variable unassigned in " + gameObject.name);
            return null;
        }
    }
}
