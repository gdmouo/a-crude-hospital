using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    [SerializeField] private bool debugging;
    [SerializeField] DialogueDataSO debugDialogue;
    public static DebugManager Instance { get; private set; }
    public bool Debugging { get { return debugging; } }

    private void Awake()
    {
        Instance = this;
    }

    public DialogueDataSO GetDebugDialogue()
    {
        return debugDialogue;
    }
}
