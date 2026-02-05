using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputMapManager : MonoBehaviour
{
    [SerializeField] private List<InputMap> inputMaps;
    [SerializeField] private MouseManager mouseManager;
    private InputMap controlFlow;
    private InputMap playerControls;
    private PlayerInputActions playerInputActions;

    public static InputMapManager Instance { get; private set; }
    public MouseManager Mouse { get { return mouseManager;  } }

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        /*
        controlFlow = GetMapByType(InputMapType.ControlFlow);
        if (controlFlow != null)
        {
            controlFlow.EnableMap(playerInputActions);
        }
        playerControls = GetMapByType(InputMapType.Player);
        if (playerControls != null)
        {
            playerControls.EnableMap(playerInputActions);
        }*/
    }
    public void ToggleMaps(List<GameStateType> toActivate, List<GameStateType> toDeactivate)
    {
        //hmm. area of itnerest
        if (controlFlow == null)
        {
            controlFlow = GetMapByType(InputMapType.ControlFlow);
        }
        if (playerControls == null)
        {
            playerControls = GetMapByType(InputMapType.Player);
        }
        //

        playerControls.DisableMap(playerInputActions);
        
        if (toDeactivate != null)
        {
            foreach (GameStateType gameStateType in toDeactivate)
            {
                InputMapType i = MapStateToType(gameStateType);

                if (i == InputMapType.Dialogue)
                {
                    controlFlow.EnableMap(playerInputActions);
                }

                InputMap inputMap = GetMapByType(i);
                if (inputMap.MapEnabled)
                {
                    inputMap.DisableMap(playerInputActions);
                }
            }
        }

        if (toActivate != null)
        {
            foreach (GameStateType gameStateType in toActivate)
            {
                InputMapType i = MapStateToType(gameStateType);

                if (i == InputMapType.HUD)
                {
                    playerControls.EnableMap(playerInputActions);
                } else if (i == InputMapType.Dialogue)
                {
                    controlFlow.DisableMap(playerInputActions);
                }

                InputMap inputMap = GetMapByType(i);
                if (!inputMap.MapEnabled)
                {
                    inputMap.EnableMap(playerInputActions);
                }
            }
        }
    }

    private InputMapType MapStateToType(GameStateType g)
    {
        switch (g) {
            case GameStateType.Menu:
                return InputMapType.Menu;
            case GameStateType.HUD:
                return InputMapType.HUD;
            case GameStateType.Inventory:
                return InputMapType.Inventory;
            case GameStateType.Dialogue:
            default:
                return InputMapType.Dialogue;
        }

    }

    private InputMap GetMapByType(InputMapType i)
    {
        if (inputMaps == null) return null;
        foreach (InputMap inputMap in inputMaps)
        {
            if (inputMap.GetInputMapType() == i) return inputMap;
        }
        return null;
    }
}
