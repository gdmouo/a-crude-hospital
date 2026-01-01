using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkBox : Interactible
{
    [SerializeField] private NPCScript npcScript;
    // Start is called before the first frame update
    private void Start()
    {
       // LoadScript();
    }

    public override void Interact(Player player)
    {
        if (npcScript == null)
        {
            return;
        }
        List<Dialogue> l = npcScript.GetDialoguePack(player.CurrentRoom);
        DialogueUIControl.Instance.LoadDialogue(l);
    }

    /*
    protected virtual void LoadScript()
    {
        AssignScript(null);
    }

    protected void AssignScript(NPCScript n)
    {
        npcScript = n;
    }*/


}
