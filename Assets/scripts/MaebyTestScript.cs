using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaebyTestScript : NPCScript
{
    protected override void LoadDialogueDict()
    {
        AddToHospitalRoomDialogue("hi", false);
        AddToHospitalRoomDialogue("yerp", true);
        Debug.Log("fart");
    }
}
