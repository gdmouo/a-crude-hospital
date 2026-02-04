using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkedToMaeby : MissionStage
{
    [SerializeField] private DialogueDataSO bitchassDialogue;

    public override void ToInvoke()
    {
        UpdateObjective();
        DialogueRunner d = TheForceManager.Instance.GetRunner();
        d.StartDialogue(bitchassDialogue);
    }

    /*
    public void AfterForceDialogue()
    {
        UpdateObjective();
    }*/
}
