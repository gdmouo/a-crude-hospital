using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : Interactible
{
    [SerializeField] private SpeakerKeys speakerName;
    public SpeakerKeys SpeakerName {  get { return speakerName; } }

    public override void Interact(Player player)
    {

        CanvasDialogue.Instance.InitDialogue(this);
    }

}