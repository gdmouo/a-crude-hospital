using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputMapManager : MonoBehaviour
{
    [SerializeField] private InputMap controlFlow;
    [SerializeField] private InputMap playerControls;
    [SerializeField] private MouseManager mouseManager;
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
        controlFlow.EnableMap(playerInputActions);
        playerControls.EnableMap(playerInputActions);
    }

    public void ToggleMaps(List<InputMap> toActivate, List<InputMap> toDeactivate)
    {
        if (toDeactivate != null)
        {
            foreach (InputMap inputMap in toDeactivate)
            {
                if (inputMap.MapEnabled)
                {
                    inputMap.DisableMap(playerInputActions);
                }
            }
        }

        if (toActivate != null)
        {
            foreach (InputMap inputMap in toDeactivate)
            {
                if (!inputMap.MapEnabled)
                {
                    inputMap.EnableMap(playerInputActions);
                }
            }
        }
    }
}
