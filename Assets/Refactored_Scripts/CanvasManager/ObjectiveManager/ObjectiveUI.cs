using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveUI : DialogueUI
{
    protected override void OnAwake()
    {
        SetOpen(true);
        SetBodyOnly("");
    }
}
