using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCanvas : StateCanvas
{
    public override StateCanvasType GetStateCanvasType()
    {
        return StateCanvasType.Dialogue;
    }
}
