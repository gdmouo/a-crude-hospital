using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState : MonoBehaviour
{
    [SerializeField] private GameStateType gameStateType;
    [SerializeField] private StateCanvas stateCanvas;
    [SerializeField] private InputMap inputMap;
    [SerializeField] private bool playerControlsEnabled;

    public GameStateType StateType { get { return gameStateType; } }
    public StateCanvas Canvas { get { return stateCanvas; } }
    public InputMap Map { get { return inputMap; } }
    public bool PlayerControlsEnabled { get { return playerControlsEnabled; } }

}