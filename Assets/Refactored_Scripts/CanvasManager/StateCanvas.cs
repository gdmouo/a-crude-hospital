using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateCanvas : MonoBehaviour, IStateCanvas
{
    protected bool canvasEnabled = false;
    public bool CanvasEnabled { get { return canvasEnabled; } }
    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    public void ActivateCanvas()
    {
        canvasEnabled = true;
        OnActivate();
    }
    public void DeactivateCanvas()
    {
        canvasEnabled = false;
        OnDeactivate();
    }

    public abstract void OnActivate();
    public abstract void OnDeactivate();

    protected abstract void OnUpdate();
}
