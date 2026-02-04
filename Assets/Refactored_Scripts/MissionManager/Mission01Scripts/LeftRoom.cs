using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRoom : MissionStage
{
    [SerializeField] private DialogueDataSO dialogueToPrint;
    [SerializeField] private Collider nextStagePassThrough;
    public override void ToInvoke()
    {
        UpdateObjective();
        if (nextStagePassThrough != null)
        {
            nextStagePassThrough.isTrigger = false;
        }
        DialogueRunner d = TheForceManager.Instance.GetRunner();
        d.StartDialogue(dialogueToPrint, AfterForceDialogue);
    }

    public void AfterForceDialogue()
    {
        nextStagePassThrough.isTrigger = true;
    }
}
