using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    //private CanvasState currentState = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum CanvasStateLabel { 
    Menu,
    Inventory,
    Dialogue,
    HUD //identifier, crosshair, hotbar, objectives
}
