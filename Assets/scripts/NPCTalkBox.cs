using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkBox : Interactible
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact(Player player)
    {
        //Debug.Log("speak to");
        //player.StoreItem(this);
        DialogueControl.Instance.EnterText("poooosay");
    }
}
