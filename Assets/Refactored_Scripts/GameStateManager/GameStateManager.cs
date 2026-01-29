using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
   // private GameStateType currentState;


}


public enum GameStateType { 
    Menu,
    Inventory,
    Dialogue,
    HUD //identifier, crosshair, hotbar, objectives
}
