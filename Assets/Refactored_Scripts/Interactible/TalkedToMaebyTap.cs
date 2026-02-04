using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkedToMaebyTap : MissionTap
{
    [SerializeField] DialogueDataSO dialogueDataSO;

    public override void OnInteractEventFinished()
    {
        GameStateManager g = GameStateManager.Instance;
        if (g == null)
        {
            return;
        }
        g.ToggleState(GameStateType.Dialogue);
        base.OnInteractEventFinished();
        //
    }

    protected override void OnInteract(Action a)
    {
        GameStateManager g = GameStateManager.Instance;
        CharacterManager d = CharacterManager.Instance;

        if (g == null || d == null)
        {
            return;
        }

        DialogueRunner dR = d.GetRunner();

        if (dR == null)
        {
            return;
        }

        g.ToggleState(GameStateType.Dialogue);
        dR.StartDialogue(dialogueDataSO, OnInteractEventFinished);
    }
}
