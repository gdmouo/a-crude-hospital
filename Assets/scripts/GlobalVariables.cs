using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables Instance { get; private set; }
    private bool menuOpen = false;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Menu instance found");
        }
        Instance = this;
    }

    public void SetGlobalMenuStatus(bool status)
    {
        menuOpen = status;
    }

    public bool IsMenuOpen()
    {
        return menuOpen;
    }
}
