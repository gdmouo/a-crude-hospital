using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputMap
{
    public void EnableMap(PlayerInputActions p);
    public void DisableMap(PlayerInputActions p);
    public InputMapType GetInputMapType();
}

public enum InputMapType { 
    Player,
    HUD,
    Menu,
    Inventory,
    Dialogue,
    ControlFlow,
    BeatRoom
}
