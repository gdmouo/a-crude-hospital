using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInput : InputMap
{
    public override InputMapType GetInputMapType()
    {
        return InputMapType.Menu;
    }

    protected override void OnDisableMap(PlayerInputActions p)
    {
        //fix vv adjust for hud, make hud lock it
        //throw new System.NotImplementedException();
    }

    protected override void OnEnableMap(PlayerInputActions p)
    {
        inputMapManager.Mouse.ToggleCursor(CursorLockMode.None);
        //throw new System.NotImplementedException();
    }
}
