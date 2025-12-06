using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : Menu
{
    public static Pause Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Menu instance found");
        }
        Instance = this;
    }
}
