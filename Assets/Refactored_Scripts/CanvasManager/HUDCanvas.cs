using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDCanvas : StateCanvas
{
    [Header("HUDCanvas specific")]
    [SerializeField] private TextMeshProUGUI identifier;
    [SerializeField] private List<GameObject> canvasesToHide; 
    protected override void OnDeactivate()
    {
        if (canvasesToHide != null)
        {
            foreach(GameObject go in canvasesToHide)
            {
                go.SetActive(false);
            }
        }
        ObjectiveManager o = ObjectiveManager.Instance;
        if (o != null)
        {
            ObjectiveUI u = o.GetObjectiveUI();
            if (u.IsOpen)
            {
                u.SetOpen(false);
            }
        }
    }
    protected override void OnActivate()
    {
        if (canvasesToHide != null)
        {
            foreach (GameObject go in canvasesToHide)
            {
                go.SetActive(true);
            }
        }
        ObjectiveManager o = ObjectiveManager.Instance;
        if (o != null)
        {
            ObjectiveUI u = o.GetObjectiveUI();
            if (!u.IsOpen)
            {
                u.SetOpen(true);
            }
        }
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
