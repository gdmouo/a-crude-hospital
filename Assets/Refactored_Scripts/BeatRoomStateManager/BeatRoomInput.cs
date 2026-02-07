using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BeatRoomInput : InputMap
{
    public bool IsWPressed()
    {
        return playerInputActions.BeatRoom.W.WasPressedThisFrame();
    }

    public bool IsAPressed()
    {
        return playerInputActions.BeatRoom.A.WasPressedThisFrame();
    }

    public bool IsSPressed()
    {
        return playerInputActions.BeatRoom.S.WasPressedThisFrame();
    }

    public bool IsDPressed()
    {
        return playerInputActions.BeatRoom.D.WasPressedThisFrame();
    }

    public bool IsUpPressed()
    {
        return playerInputActions.BeatRoom.Up.WasPressedThisFrame();
    }

    public bool IsDownPressed()
    {
        return playerInputActions.BeatRoom.Down.WasPressedThisFrame();
    }

    public bool IsLeftPressed()
    {
        return playerInputActions.BeatRoom.Left.WasPressedThisFrame();
    }

    public bool IsRightPressed()
    {
        return playerInputActions.BeatRoom.Right.WasPressedThisFrame();
    }


    protected override void OnDisableMap(PlayerInputActions p)
    {
        p.BeatRoom.Disable();
    }

    protected override void OnEnableMap(PlayerInputActions p)
    {
        p.BeatRoom.Enable();
    }

    public override InputMapType GetInputMapType()
    {
        return InputMapType.BeatRoom;
    }
}
