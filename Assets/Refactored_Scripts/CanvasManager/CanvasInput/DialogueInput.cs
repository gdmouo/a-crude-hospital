using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueInput : InputMap
{
    private Vector2 mouseInput;
    public override InputMapType GetInputMapType()
    {
        return InputMapType.Dialogue;
    }

    protected override void OnDisableMap(PlayerInputActions p)
    {
        p.Dialogue.Hover.performed -= ctx => mouseInput = ctx.ReadValue<Vector2>();
        p.Dialogue.Hover.canceled -= ctx => mouseInput = Vector2.zero;
        p.Dialogue.Click.performed -= OnClick;
        p.Dialogue.Disable();
    }
    protected override void OnEnableMap(PlayerInputActions p)
    {
        p.Dialogue.Enable();
        p.Dialogue.Hover.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();
        p.Dialogue.Hover.canceled += ctx => mouseInput = Vector2.zero;
        p.Dialogue.Click.performed += OnClick;
        inputMapManager.Mouse.ToggleCursor(CursorLockMode.None);
    }

    private void OnClick(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        CharacterManager n = CharacterManager.Instance;
        //
        if (n != null)
        {
            DialogueRunner d = n.GetRunner();
            if (d != null)
            {
                d.OnAdvancePressed();
            }
        }
    }
}
