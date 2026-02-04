using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDCanvas : StateCanvas
{
    [SerializeField] private TextMeshProUGUI identifier;
    public override void DeactivateCanvas()
    {
    }

    public override StateCanvasType GetStateCanvasType()
    {
        return StateCanvasType.HUD;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (identifier != null)
        {
            PlayerCharacter player = PlayerCharacter.Instance;
            if (player != null)
            {
                Interactible i = player.GetSelectedInteractible();
                if (i != null)
                {
                    string updateTo = i.GetName();
                    UpdateUniqueText(identifier, updateTo);
                } else
                {
                    UpdateUniqueText(identifier, string.Empty);
                }
            } else
            {
                UpdateUniqueText(identifier, string.Empty);
            }
        }
    }

    private void UpdateUniqueText(TextMeshProUGUI t, string updateTo)
    {
        if (updateTo != t.text)
                    {
            t.text = updateTo;
        }
    }
}
