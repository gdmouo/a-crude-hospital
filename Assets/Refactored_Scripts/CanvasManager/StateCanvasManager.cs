using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateCanvasManager : MonoBehaviour
{
    [SerializeField] List<StateCanvas> stateCanvases;
    public static StateCanvasManager Instance {  get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    /*
    public void ToggleCanvases(List<StateCanvas> toActivate, List<StateCanvas> toDeactivate)
    {
        if (toDeactivate != null)
        {
            foreach (StateCanvas stateCanvas in toDeactivate)
            {
                if (stateCanvas.CanvasEnabled)
                {
                    stateCanvas.DeactivateCanvas();
                }
            }
        }

        if (toActivate != null)
        {
            foreach (StateCanvas stateCanvas in toActivate)
            {
                if (!stateCanvas.CanvasEnabled)
                {
                    stateCanvas.ActivateCanvas();
                }
            }
        }
    }*/


    public void ToggleCanvases(List<GameStateType> toActivate, List<GameStateType> toDeactivate)
    {
        if (toDeactivate != null)
        {
            foreach (GameStateType gameStateType in toDeactivate)
            {
                StateCanvas stateCanvas = GetCanvasByType(MapStateToType(gameStateType));
                if (stateCanvas.CanvasEnabled)
                {
                    stateCanvas.DeactivateCanvas();
                }
            }
        }

        if (toActivate != null)
        {
            foreach (GameStateType gameStateType in toActivate)
            {
                StateCanvas stateCanvas = GetCanvasByType(MapStateToType(gameStateType));
                if (!stateCanvas.CanvasEnabled)
                {
                    stateCanvas.ActivateCanvas();
                }
            }
        }
    }

    private StateCanvasType MapStateToType(GameStateType g)
    {
        switch (g)
        {
            case GameStateType.Menu:
                return StateCanvasType.Menu;
            case GameStateType.HUD:
                return StateCanvasType.HUD;
            case GameStateType.Inventory:
                return StateCanvasType.Inventory;
            case GameStateType.Dialogue:
            default:
                return StateCanvasType.Dialogue;
        }

    }

    private StateCanvas GetCanvasByType(StateCanvasType s)
    {
        if (stateCanvases == null) return null;
        foreach (StateCanvas stateCanvas in stateCanvases)
        {
            if (stateCanvas.GetStateCanvasType() == s) return stateCanvas;
        }
        return null;
    }
}

public enum StateCanvasType
{
    Menu,
    Inventory,
    Dialogue,
    HUD //identifier, crosshair, hotbar, objectives
}