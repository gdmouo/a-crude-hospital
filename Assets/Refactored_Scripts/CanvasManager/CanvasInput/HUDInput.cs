using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class HUDInput : InputMap
{
    public override InputMapType GetInputMapType()
    {
        return InputMapType.HUD;
    }

    protected override void OnEnableMap(PlayerInputActions p)
    {
        p.HUD.Enable();
        playerInputActions.HUD.Hotbar1.performed += KeyboardOne_performed;
        playerInputActions.HUD.Hotbar2.performed += KeyboardTwo_performed;
        playerInputActions.HUD.Hotbar3.performed += KeyboardThree_performed;
        if (inputMapManager != null)
        {
            inputMapManager.Mouse.ToggleCursor(CursorLockMode.None);
        }
    }

    protected override void OnDisableMap(PlayerInputActions p)
    {
        playerInputActions.HUD.Hotbar1.performed -= KeyboardOne_performed;
        playerInputActions.HUD.Hotbar2.performed -= KeyboardTwo_performed;
        playerInputActions.HUD.Hotbar3.performed -= KeyboardThree_performed;
        p.HUD.Disable();
        if (inputMapManager != null)
        {
            inputMapManager.Mouse.ToggleCursor(CursorLockMode.Locked);
        }
    }

    private void KeyboardOne_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
       // player.AccessInventory(0);
    }

    private void KeyboardTwo_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
       // player.AccessInventory(1);
    }

    private void KeyboardThree_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //player.AccessInventory(2);
    }


}
