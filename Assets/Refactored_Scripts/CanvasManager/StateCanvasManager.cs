using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateCanvasManager : MonoBehaviour
{
    public static StateCanvasManager Instance {  get; private set; }

    private void Awake()
    {
        Instance = this;
    }

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
    }
}
