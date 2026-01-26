using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : Driver
{
    [SerializeField] private UnityEvent invokeOnEscape;

    private PlayerInputActions playerInputActions;
    private Vector2 mouseInput;
    private bool cursorLocked = false;


    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();
        playerInputActions.Player.Look.canceled += ctx => mouseInput = Vector2.zero;
        playerInputActions.Player.Pause.performed += Escape_performed;

    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public Vector2 GetRotationVector()
    {
        float mouseX = mouseInput.x;
        float mouseY = mouseInput.y;
        Vector2 inputVector = new(mouseX, mouseY);
        return inputVector;
    }

    private void Escape_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        invokeOnEscape?.Invoke();
    }

    //JFIOEJFLKAJSKLZDDBUEDENUG
    public void TestEscapeAction()
    {
        if (cursorLocked)
        {
            UnlockCursor();
            cursorLocked = false;
        } else
        {
            LockCursor();
            cursorLocked = true;
        }
    }
}
