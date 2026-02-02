using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueDataSO")]
public class DialogueDataSO : ScriptableObject
{
    public List<DialogueLine> lines;
}

[System.Serializable]
public struct DialogueLine
{
    public string speaker;
    [TextArea(2, 6)] public string text;
}
