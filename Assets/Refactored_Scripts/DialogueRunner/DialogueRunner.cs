using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class DialogueRunner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected DialogueUI ui;

    [Header("Typewriter")]
    [SerializeField] protected float textSpeed = 0.1f;

    protected DialogueDataSO currentDialogueData;
    protected int index = -1;

    protected Coroutine typingRoutine;
    protected bool isTyping = false;
    protected bool requestedAdvance = false;

    protected Action onEndDialogue = null;

    public virtual void StartDialogue(DialogueDataSO asset)
    {
        DebugManager d = DebugManager.Instance;
        if (d != null)
        {
            if (d.Debugging)
            {
                asset = d.GetDebugDialogue();
            }
        }

        if (!ui || asset == null || asset.lines == null || asset.lines.Count == 0) return;

        currentDialogueData = asset;
        index = -1;
        ui.SetOpen(true);
        NextLine();
    }

    public virtual void StartDialogue(DialogueDataSO asset, Action a)
    {
        DebugManager d = DebugManager.Instance;
        if (d != null)
        {
            if (d.Debugging)
            {
                asset = d.GetDebugDialogue();
            }
        }


        if (!ui || asset == null || asset.lines == null || asset.lines.Count == 0) return;

        currentDialogueData = asset;
        onEndDialogue = a;
        index = -1;
        ui.SetOpen(true);
        NextLine();
    }

    protected virtual void NextLine()
    {
        index++;

        if (currentDialogueData == null || index >= currentDialogueData.lines.Count)
        {
            EndDialogue();
            return;
        }

        DialogueLine dialogueLine = currentDialogueData.lines[index];
        ui.SetText(dialogueLine.speaker, "");

        StopTyping();
        typingRoutine = StartCoroutine(TypeLine(dialogueLine.text));
    }
    protected virtual IEnumerator TypeLine(string fullText)
    {
        isTyping = true;
        ui.SetBodyOnly("");

        for (int i = 0; i < fullText.Length; i++)
        {
            if (requestedAdvance)
            {
                ui.SetBodyOnly(fullText);
                break;
            }

            ui.SetBodyOnly(fullText.Substring(0, i + 1));
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    public virtual void EndDialogue()
    {
        StopTyping();
        currentDialogueData = null;
        index = -1;
        ui.SetOpen(false);
        onEndDialogue?.Invoke();
        onEndDialogue = null;
    }

    protected virtual void StopTyping()
    {
        if (typingRoutine != null)
        {
            StopCoroutine(typingRoutine);
            typingRoutine = null;
        }
        isTyping = false;
        requestedAdvance = false;
    }

    public void OnAdvancePressed()
    {
        if (currentDialogueData == null) return;

        if (isTyping)
        {
            requestedAdvance = true;
            return;
        }

        NextLine();
    }
}
