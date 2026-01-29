using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameState", menuName = "GameStateSO")]
public class GameStateSO : ScriptableObject
{
    public GameStateType gameStateType;
    public GameObject canvasObject;
    public InputMapType inputMapType;
}


