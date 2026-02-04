using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCanvas : StateCanvas
{
    public override void DeactivateCanvas()
    {
    }
    public override StateCanvasType GetStateCanvasType()
    {
        return StateCanvasType.Dialogue;
    }
}
