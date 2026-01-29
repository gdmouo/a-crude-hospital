using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputMapManager : MonoBehaviour
{
    [SerializeField] private Transform inputMapObjects;
    private List<InputMap> inputMaps;

    private PlayerInputActions playerInputActions;

    public static InputMapManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        inputMaps = GetMapChildren(inputMapObjects);
        InputMap controlFlowMap = GetMapFromList(InputMapType.ControlFlow, inputMaps);

        if (controlFlowMap == null)
        {
            Debug.LogError("Critical variable unassigned in " + gameObject.name);
            return;
        } else
        {
            EnableMap(InputMapType.ControlFlow);
        }
    }


    //vv current, exhcange for togglemap
    public void EnableMap(InputMapType i)
    {
        DisableAllMaps();

        foreach (InputMap map in inputMaps)
        {
            if (map.GetInputMapType() == i && !map.MapEnabled)
            {
                map.EnableMap(playerInputActions);
            }
        }
        Debug.Log("map " + i.ToString() + " enabled.");
    }

    //if map is exempted from deactivation
    private bool IsExempted(InputMap map)
    {
        if (map.GetInputMapType() == InputMapType.ControlFlow)
        {
            return true;
        }
        return false;
    }

    private InputMap GetMapFromList(InputMapType i, List<InputMap> iM)
    {
        foreach (InputMap map in iM)
        {
            if (map.GetInputMapType() == i)
            {
                return map;
            }
        }
        return null;
    }

    private void DisableAllMaps()
    {
        foreach (InputMap map in inputMaps)
        {
            if (!IsExempted(map) && map.MapEnabled)
            {
                map.DisableMap(playerInputActions);
                Debug.Log("map " + map.GetInputMapType().ToString() + " disabled.");
            }
        }
    }

    private List<InputMap> GetMapChildren(Transform parent)
    {
        List<InputMap> result =     new List<InputMap>();
        foreach (Transform child in parent)
        {
            if (child.gameObject.TryGetComponent<InputMap>(out InputMap map))
            {
                result.Add(map);
            }
        }
        return result;
    }
}
