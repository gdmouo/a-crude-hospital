using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFlowInput : InputMap
{
    protected override void OnDisableMap(PlayerInputActions p)
    {
        p.ControlFlow.Disable();
    }

    protected override void OnEnableMap(PlayerInputActions p)
    {
        p.ControlFlow.Enable();
        p.ControlFlow.ToggleMenu.performed += ToggleMenu_performed;
        p.ControlFlow.ToggleInventory.performed += ToggleInventory_performed;
    }

    public override InputMapType GetInputMapType()
    {
        return InputMapType.ControlFlow;
    }

    private void ToggleMenu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        GameStateManager g = GameStateManager.Instance;
        
        if (g != null)
        {
            g.ToggleState(GameStateType.Menu);
        }
    }

    private void ToggleInventory_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        GameStateManager g = GameStateManager.Instance;

        if (g != null)
        {
            g.ToggleState(GameStateType.Inventory);
        }
    }
}
