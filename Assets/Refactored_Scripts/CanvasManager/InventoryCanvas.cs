using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : StateCanvas
{
    [SerializeField] private InventoryDisplay inventoryDisplay;
    public override StateCanvasType GetStateCanvasType()
    {
        return StateCanvasType.Inventory;
    }
    protected override void OnActivate()
    {
        base.OnActivate();
        inventoryDisplay.OnActivate();

    }
    protected override void OnDeactivate()
    {
        inventoryDisplay.OnDeactivate();
        base.OnDeactivate();
    }
}
