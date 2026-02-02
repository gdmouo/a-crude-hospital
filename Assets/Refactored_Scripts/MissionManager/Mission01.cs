using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class Mission01 : Mission
{
    [Header("Mission01")]
    [SerializeField] private Mission01StageLabel startingStage;
    [SerializeField] List<Mission01Stage> stageList;
    public override void Init()
    {
        currentStage = startingStage.ToString();
        stageStartFunctions = new Dictionary<string, UnityEvent>();

        foreach (Mission01Stage stage in stageList)
        {
            stageStartFunctions.Add(stage.stageLabel.ToString(), stage.toInvoke);
        }
    }

    protected override void OnPassThroughTriggered(string id)
    {
        string LeftBathroomTrigger = "LeftBathroomTrigger";
        string LeftRoomTrigger = "LeftRoomTrigger";

        if (currentStage == Mission01StageLabel.LeftBathroom.ToString() && id == LeftBathroomTrigger)
        {
            Advance(Mission01StageLabel.LeftRoom.ToString());
        } else if (currentStage == Mission01StageLabel.LeftRoom.ToString()  && id == LeftRoomTrigger)
        {
            Advance(Mission01StageLabel.TalkedToMaeby.ToString());
        }
    }

    protected override void OnPickupCollected(string id)
    {
        string KeycardPickup = "KeycardPickup";
 
        if (currentStage == Mission01StageLabel.FoundKeycard.ToString() && id == KeycardPickup)
        {
            Advance(Mission01StageLabel.MissionEnded.ToString());
        }
    }

    protected override void OnTapEventFinished(string id)
    {
        string TalkedToMaebyEvent = "TalkedToMaebyEvent";

        if (currentStage == Mission01StageLabel.TalkedToMaeby.ToString() && id == TalkedToMaebyEvent)
        {
            Advance(Mission01StageLabel.FoundKeycard.ToString());
        }
    }
}

public enum Mission01StageLabel { 
    NotStarted,
    LeftBathroom,
    LeftRoom,
    TalkedToMaeby,
    FoundKeycard,
    /*
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
    FoundMaebyGone,*/
    MissionEnded
}

[System.Serializable]
public struct Mission01Stage
{
    public Mission01StageLabel stageLabel;
    public UnityEvent toInvoke;
}
