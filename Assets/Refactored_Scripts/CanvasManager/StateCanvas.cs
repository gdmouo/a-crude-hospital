using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateCanvas : MonoBehaviour, IStateCanvas
{
    [SerializeField] protected GameObject visualsParent;
    protected bool canvasEnabled = false;
    public bool CanvasEnabled { get { return canvasEnabled; } }
    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    public void ActivateCanvas()
    {
        OnActivate();
        canvasEnabled = true;
    }
    public virtual void DeactivateCanvas()
    {
        OnDeactivate();
        canvasEnabled = false;
    }

    protected virtual void OnActivate()
    {
        if (visualsParent == null) return;
        if (!visualsParent.activeSelf)
        {
            visualsParent.SetActive(true);
        }
    }
    protected virtual void OnDeactivate()
    {
        if (visualsParent == null) return;
        if (visualsParent.activeSelf)
        {
            visualsParent.SetActive(false);
        }
    }

    protected virtual void OnUpdate()
    {

    }

    public abstract StateCanvasType GetStateCanvasType();
}
