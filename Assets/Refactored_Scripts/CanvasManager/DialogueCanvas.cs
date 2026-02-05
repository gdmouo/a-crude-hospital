using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCanvas : StateCanvas
{
    [SerializeField] private List<GameObject> canvasesToHide;
    protected override void OnDeactivate()
    {
        if (canvasesToHide != null)
        {
            foreach (GameObject go in canvasesToHide)
            {
                go.SetActive(false);
            }
        }
    }
    protected override void OnActivate()
    {
        if (canvasesToHide != null)
        {
            foreach (GameObject go in canvasesToHide)
            {
                go.SetActive(true);
            }
        }
    }
    public override StateCanvasType GetStateCanvasType()
    {
        return StateCanvasType.Dialogue;
    }
}
