using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Player player;

    private PlayerCamera firstPersonCamera;
    private Vector2 mouseInput;

    private Menu menu;

    private LockMouse lockMouse;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();
        playerInputActions.Player.Look.canceled += ctx => mouseInput = Vector2.zero; // Reset when mouse stops
        playerInputActions.Player.Pause.performed += Escape_performed;
        playerInputActions.Player.Jump.performed += Jump_performed;
    }

    private void Start()
    {
        player = Player.Instance;
        firstPersonCamera = PlayerCamera.Instance;
        menu = Menu.Instance;
        lockMouse = gameObject.GetComponent<LockMouse>();
        lockMouse.Toggle(false);
    }
    private void Escape_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        lockMouse.Toggle(menu.Toggle());
    }
    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        player.Jump();
        Debug.Log("Jumped");
    }
    private void Update()
    {
        if (!menu.SwitchedOn)
        {
            HandleWASD();
            HandleBob();
        }
        HandleHoldSpace();
    }

    private void HandleWASD() {
        player.Move(GetMovementVectorNormalized(), firstPersonCamera.transform.forward, firstPersonCamera.transform.right);
    }
    private void HandleBob()
    {
        firstPersonCamera.Move(GetRotationVector());
        player.Rotate(firstPersonCamera.transform.eulerAngles);
    }
    private Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }

    private Vector2 GetRotationVector()
    {
        float mouseX = mouseInput.x;
        float mouseY = mouseInput.y;
        Vector2 inputVector = new(mouseX, mouseY);
        return inputVector;
    }


    private void HandleHoldSpace()
    {
        if (playerInputActions.Player.Jump.IsPressed())
        {
            player.Jump();
        }
        else
        {
            player.StopJumping();
        }
    }
}
