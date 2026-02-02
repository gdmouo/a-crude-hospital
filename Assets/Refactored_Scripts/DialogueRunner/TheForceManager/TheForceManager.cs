using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheForceManager : MonoBehaviour
{
    [SerializeField] private TheForceRunner theForceRunner;
    public static TheForceManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public DialogueRunner GetRunner()
    {
        return theForceRunner;
    }
}
