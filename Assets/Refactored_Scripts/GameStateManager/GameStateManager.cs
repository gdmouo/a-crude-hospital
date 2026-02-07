using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : StateManager
{
    protected override void OnStart()
    {
        ToggleState(GameStateType.HUD);
    }
}


public enum GameStateType { 
    Menu,
    Inventory,
    Dialogue,
    HUD,
    BeatRoom//identifier, crosshair, hotbar, objectives
}
