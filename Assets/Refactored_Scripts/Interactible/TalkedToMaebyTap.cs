using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkedToMaebyTap : MissionTap
{
    [SerializeField] private DialogueDataSO dialogueDataSO;
    [SerializeField] private Character maeby;

    public override void OnInteractEventFinished()
    {
        GameStateManager g = GameStateManager.Instance;
        if (g == null)
        {
            return;
        }
        g.ToggleState(GameStateType.Dialogue);
        base.OnInteractEventFinished();
        Destroy(gameObject);
    }

    protected override void OnInteract(Action a)
    {
        if (interacted)
        {
            return;
        }
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

    public override string GetName()
    {
        return "Talk to " + maeby.GetCharacterType().ToString() + " ?";
    }
}
