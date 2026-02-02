using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TheForceRunner : DialogueRunner
{
    [Header("TheForceRunner Variables")]
    [SerializeField] protected float nextLineDelay = 4f;
    protected override IEnumerator TypeLine(string fullText)
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

        yield return new WaitForSeconds(nextLineDelay);
        NextLine();
    }
}
