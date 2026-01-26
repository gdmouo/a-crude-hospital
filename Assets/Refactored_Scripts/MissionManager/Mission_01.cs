using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_01 : Mission
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public enum Mission01Stage { 
    NotStarted,
    LeftBathroom,
    LeftRoom,
    TalkedToMaeby,
    FoundKeycard,
    EnteredStockRoom,
    FoundAllPillBottles,
    LeftStockRoom,
    EnteredSecurityRoom,
    FootageDeleted,
    MaebyEntered,
    MaebyCheckPassed,
    LeftSecurityRoom,
    FoundWater,
    TeleportedToTheUpperDeck,
    FoundObjective,
    EnteredHallway,
    FoundBeatBox,
    DefeatedHatman,
    PickedUpHatmanHat,
    TeleportedToHospital,
    FoundBeatBoxStation,
    FoundMaebyGone,
    MissionEnded
}

