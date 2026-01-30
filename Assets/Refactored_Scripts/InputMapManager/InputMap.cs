using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputMap : MonoBehaviour, IInputMap
{
    protected bool mapEnabled = false;
    public bool MapEnabled { get { return mapEnabled; } }
    protected PlayerInputActions playerInputActions;

    protected InputMapManager inputMapManager;

    public void EnableMap(PlayerInputActions p)
    {
        if (inputMapManager == null)
        {
            inputMapManager = InputMapManager.Instance;
        }

        if (playerInputActions == null)
        {
            playerInputActions = p;
        }
        mapEnabled = true;
        OnEnableMap(p);
    }
    public void DisableMap(PlayerInputActions p)
    {
        mapEnabled = false;
        OnDisableMap(p);
        //is this necessary?
        if (playerInputActions != null)
        {
            playerInputActions = null;
        }
    }

    public abstract InputMapType GetInputMapType();

    protected abstract void OnEnableMap(PlayerInputActions p);
    protected abstract void OnDisableMap(PlayerInputActions p);
}
