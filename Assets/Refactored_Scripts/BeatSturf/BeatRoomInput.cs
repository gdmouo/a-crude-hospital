using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BeatRoomInput : InputMap
{
    public bool IsWPressed()
    {
        return playerInputActions.BeatRoom.W.IsPressed();
    }

    public bool IsAPressed()
    {
        return playerInputActions.BeatRoom.A.IsPressed();
    }

    public bool IsSPressed()
    {
        return playerInputActions.BeatRoom.S.IsPressed();
    }

    public bool IsDPressed()
    {
        return playerInputActions.BeatRoom.D.IsPressed();
    }

    public bool IsUpPressed()
    {
        return playerInputActions.BeatRoom.Up.IsPressed();
    }

    public bool IsDownPressed()
    {
        return playerInputActions.BeatRoom.Down.IsPressed();
    }

    public bool IsLeftPressed()
    {
        return playerInputActions.BeatRoom.Left.IsPressed();
    }

    public bool IsRightPressed()
    {
        return playerInputActions.BeatRoom.Right.IsPressed();
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
