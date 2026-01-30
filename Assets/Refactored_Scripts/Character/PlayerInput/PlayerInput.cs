using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : InputMap
{
    private Vector2 mouseInput;

    //REQUIRES: MapEnabled = true;
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }

    public Vector2 GetRotationVector()
    {
        float mouseX = mouseInput.x;
        float mouseY = mouseInput.y;
        Vector2 inputVector = new(mouseX, mouseY);
        return inputVector;
    }

    public override InputMapType GetInputMapType()
    {
        return InputMapType.Player;
    }

    protected override void OnEnableMap(PlayerInputActions p)
    {
        p.Player.Enable();
        p.Player.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();
        p.Player.Look.canceled += ctx => mouseInput = Vector2.zero;
        if (inputMapManager != null)
        {
            inputMapManager.Mouse.ToggleCursor(CursorLockMode.Locked);
        }
    }

    protected override void OnDisableMap(PlayerInputActions p)
    {
        p.Player.Look.performed -= OnLookPerformed;
        p.Player.Look.canceled -= OnLookCanceled;
        p.Player.Disable();
        if (inputMapManager != null)
        {
            inputMapManager.Mouse.ToggleCursor(CursorLockMode.None);
        }
    }

    private void OnLookPerformed(InputAction.CallbackContext ctx)
    {
        mouseInput = ctx.ReadValue<Vector2>();
    }

    private void OnLookCanceled(InputAction.CallbackContext ctx)
    {
        mouseInput = Vector2.zero;
    }


}
