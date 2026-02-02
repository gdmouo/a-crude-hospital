using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : InputMap
{
    public override InputMapType GetInputMapType()
    {
        return InputMapType.Inventory;
    }

    protected override void OnDisableMap(PlayerInputActions p)
    {
    }

    protected override void OnEnableMap(PlayerInputActions p)
    {
        inputMapManager.Mouse.ToggleCursor(CursorLockMode.None);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
