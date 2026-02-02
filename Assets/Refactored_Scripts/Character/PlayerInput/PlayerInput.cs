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
        p.Player.Click.performed += OnClick;
        if (inputMapManager != null)
        {
            inputMapManager.Mouse.ToggleCursor(CursorLockMode.Locked);
        }
    }

    protected override void OnDisableMap(PlayerInputActions p)
    {
        p.Player.Look.performed -= ctx => mouseInput = ctx.ReadValue<Vector2>();
        p.Player.Look.canceled -= ctx => mouseInput = Vector2.zero;
        p.Player.Click.performed -= OnClick;
        p.Player.Disable();
    }

   private void OnClick(UnityEngine.InputSystem.InputAction.CallbackContext obj)
   {
        PlayerCharacter player = PlayerCharacter.Instance;
        if (player != null)
        {
            player.InteractWithItemSelected();
        }
   }
}
