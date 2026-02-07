using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputMapManager : MonoBehaviour, IInputMapManager
{
    [SerializeField] protected List<InputMap> inputMaps;
    [SerializeField] protected MouseManager mouseManager;
    //private InputMap controlFlow;
    // private InputMap playerControls;
    protected PlayerInputActions playerInputActions;

    public static InputMapManager Instance { get; private set; }
    public MouseManager Mouse { get { return mouseManager; } }

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();

    }
    // Start is called before the first frame update
    private void Start()
    {
        OnStart();
    }

    protected virtual void OnStart()
    {
        /*
        if (controlFlow == null)
        {
            controlFlow = GetMapByType(InputMapType.ControlFlow);
            if (!controlFlow.MapEnabled)
            {
                controlFlow.EnableMap(playerInputActions);
            }
        }
        if (playerControls == null)
        {
            playerControls = GetMapByType(InputMapType.Player);
            if (!playerControls.MapEnabled)
            {
                playerControls.EnableMap(playerInputActions);
            }
        }*/
    }
    public void ToggleMaps(List<GameStateType> toActivate, List<GameStateType> toDeactivate)
    {
        BeforeToggleMap();
        //hmm. area of itnerest
        //SomeBullshit();
        //

        //playerControls.DisableMap(playerInputActions);

        if (toDeactivate != null)
        {
            foreach (GameStateType gameStateType in toDeactivate)
            {
                InputMapType i = MapStateToType(gameStateType);

                BeforeDeactivateMap(i);
                /*
                if (i == InputMapType.Dialogue)
                {
                    controlFlow.EnableMap(playerInputActions);
                }
                */

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

                BeforeActivateMap(i);

               

                InputMap inputMap = GetMapByType(i);
                if (!inputMap.MapEnabled)
                {
                    inputMap.EnableMap(playerInputActions);
                }
            }
        }
    }

    protected virtual void BeforeToggleMap()
    {

    }

    protected virtual void BeforeDeactivateMap(InputMapType i)
    {

    }

    protected virtual void BeforeActivateMap(InputMapType i)
    {

    }

    protected InputMapType MapStateToType(GameStateType g)
    {
        switch (g)
        {
            case GameStateType.Menu:
                return InputMapType.Menu;
            case GameStateType.HUD:
                return InputMapType.HUD;
            case GameStateType.Inventory:
                return InputMapType.Inventory;
            case GameStateType.BeatRoom:
                return InputMapType.BeatRoom;
            case GameStateType.Dialogue:
            default:
                return InputMapType.Dialogue;
        }
    }

    public InputMap GetMapByType(InputMapType i)
    {
        if (inputMaps == null) return null;
        foreach (InputMap inputMap in inputMaps)
        {
            if (inputMap.GetInputMapType() == i) return inputMap;
        }
        return null;
    }
}
