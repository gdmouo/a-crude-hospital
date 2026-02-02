using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission01 : Mission
{
    public override void Init()
    {
        stageStartFunctions = new Dictionary<string, Action>()
        {
            {Mission01Stage.NotStarted.ToString(), OnNotStarted},
            {Mission01Stage.LeftBathroom.ToString(), OnLeftBathroom},
            {Mission01Stage.LeftRoom.ToString(), OnLeftRoom},
            {Mission01Stage.TalkedToMaeby.ToString(), OnTalkedToMaeby},
            {Mission01Stage.FoundKeycard.ToString(), OnFoundKeycard},
            {Mission01Stage.MissionEnded.ToString(), OnMissionEnded},
        };
    }

    protected override void OnPassThroughTriggered(string id)
    {
        string LeftBathroomTrigger = "LeftBathroomTrigger";
        string LeftRoomTrigger = "LeftRoomTrigger";

        if (currentStage == Mission01Stage.LeftBathroom.ToString() && id == LeftBathroomTrigger)
        {
            Advance(Mission01Stage.LeftRoom.ToString());
        } else if (currentStage == Mission01Stage.LeftRoom.ToString()  && id == LeftRoomTrigger)
        {
            Advance(Mission01Stage.TalkedToMaeby.ToString());
        }
    }

    protected override void OnPickupCollected(string id)
    {
        string KeycardPickup = "KeycardPickup";
 
        if (currentStage == Mission01Stage.FoundKeycard.ToString() && id == KeycardPickup)
        {
            Advance(Mission01Stage.MissionEnded.ToString());
        }
    }

    protected override void OnTapEventFinished(string id)
    {
        string TalkedToMaebyEvent = "TalkedToMaebyEvent";

        if (currentStage == Mission01Stage.TalkedToMaeby.ToString() && id == TalkedToMaebyEvent)
        {
            Advance(Mission01Stage.FoundKeycard.ToString());
        }
    }

    public void OnNotStarted()
    {

    }

    public void OnLeftBathroom()
    {

    }

    public void OnLeftRoom()
    {

    }

    public void OnTalkedToMaeby()
    {
    }


    public void OnFoundKeycard()
    {

    }

    public void OnMissionEnded()
    {

    }

}

public enum Mission01Stage { 
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

