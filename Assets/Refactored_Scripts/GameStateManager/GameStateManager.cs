using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private List<GameState> gameStates;
    private GameState currentGameState;
    
    public static GameStateManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

    }
    // Start is called before the first frame update
    private void Start()
    {
        //hm. area of itnetstes
        ToggleState(GameStateType.HUD);
        //
    }

    public void ToggleState(GameStateType gameStateType)
    {
        bool activate = true;

        if (currentGameState != null)
        {
            GameStateType currStateType = currentGameState.StateType;
            activate = currStateType != gameStateType;
        }

        GameState gameStateTo = GetStateByLabel(gameStateType);

        if (gameStateTo == null)
        {
            return;
        }

        if (activate)
        {
            gameStateTo.ActivateState();
        } else
        {
            gameStateTo.DeactivateState();
        }
    }

    public void UpdateCurrState(GameState gameState)
    {
        currentGameState = gameState;
    }

    public GameState GetCurrentState()
    {
        return currentGameState;
    }

    public GameState GetHUDState()
    {
        return GetStateByLabel(GameStateType.HUD);
    }

    private GameState GetStateByLabel(GameStateType g)
    {
        if (gameStates == null) return null;
        foreach (GameState state in gameStates)
        {
            if (state.StateType == g) return state;
        }
        return null;
    }
}


public enum GameStateType { 
    Menu,
    Inventory,
    Dialogue,
    HUD //identifier, crosshair, hotbar, objectives
}
