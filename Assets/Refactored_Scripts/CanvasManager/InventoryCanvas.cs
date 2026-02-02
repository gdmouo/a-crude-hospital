using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : StateCanvas
{
    public override StateCanvasType GetStateCanvasType()
    {
        return StateCanvasType.Inventory;
    }
}
