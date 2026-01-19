using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputActions playerInputActions;
    private Player player;

    private PlayerCamera firstPersonCamera;
    private Vector2 mouseInput;

    private Pause pause;

    private LockMouse lockMouse;
    private Backpack backpack;

    private bool playerControlsDisabled = false;

    private IntInvGUI selectedIIGUI;

    private bool dialogueActivated = false;
    private DialogueRunner dialogueRunner = null;


    //private BeatPadController bpCont;
  //  bpCont = BeatPadController.Instance;
       

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Menu instance found");
        }
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();
        playerInputActions.Player.Look.canceled += ctx => mouseInput = Vector2.zero; // Reset when mouse stops
        playerInputActions.Player.Pause.performed += Escape_performed;
        playerInputActions.Player.Jump.performed += Space_performed;
        playerInputActions.Player.InventorySlotOne.performed += KeyboardOne_performed;
        playerInputActions.Player.InventorySlotTwo.performed += KeyboardTwo_performed;
        playerInputActions.Player.InventorySlotThree.performed += KeyboardThree_performed;
        playerInputActions.Player.Click.performed += OnClick;
        playerInputActions.Player.Backpack.performed += Backpack_performed;
        playerInputActions.Player.FallOut.performed += FallOut_performed;
    }

    private void Start()
    {
        player = Player.Instance;
        firstPersonCamera = PlayerCamera.Instance;
        pause = Pause.Instance;
        backpack = Backpack.Instance;
        lockMouse = gameObject.GetComponent<LockMouse>();
        lockMouse.Toggle(false);
    }

    private void OnClick(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (dialogueActivated && dialogueRunner != null)
        {
            dialogueRunner.ClickDialogueRunner();
            return;
        }
        player.InteractWithSelectedItem();
    }
    private void Escape_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        lockMouse.Toggle(pause.Toggle());
    }

    private void Backpack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        lockMouse.Toggle(backpack.Toggle());
    }

    private void FallOut_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //lockMouse.Toggle(pause.Toggle());
        if (selectedIIGUI != null)
        {
            selectedIIGUI.GUIHoldingInteract();
        }
    }
    private void Space_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        player.Jump();
        Debug.Log("Jumped");
    }

    private void KeyboardOne_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        player.AccessInventory(0);
    }

    private void KeyboardTwo_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        player.AccessInventory(1);
    }

    private void KeyboardThree_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        player.AccessInventory(2);
    }
    private void Update()
    {
        if (!playerControlsDisabled)
        {
            HandleWASD();
            HandleBob();
            HandleHoldSpace();
        }
    }

    public void ToggleIsSpeaking(bool b, DialogueRunner r)
    {
        dialogueRunner = r;
        dialogueActivated = b;
    }

    public void ToggleMouse(bool v)
    {
        lockMouse.Toggle(v);
    }

    public bool IsMouseHolding()
    {
        return playerInputActions.Player.Click.IsPressed();
    }

    public void TogglePlayerControls(bool toggle)
    {
        playerControlsDisabled = toggle;
    }

    public void SetSelectedIIGUI(IntInvGUI iiGUI)
    {
        selectedIIGUI = iiGUI;
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
