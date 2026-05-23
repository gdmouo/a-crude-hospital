using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Progress;

public class Mission01 : Mission
{
    [Header("Mission01")]
    [SerializeField] private Mission01StageLabel startingStage;
    [SerializeField] List<Mission01Stage> stageList;

    private int barkadrylCount = 0;
    public override void Init()
    {
        currentStage = startingStage.ToString();
        stageStartFunctions = new Dictionary<string, MissionStage>();

        foreach (Mission01Stage stage in stageList)
        {
            stageStartFunctions.Add(stage.stageLabel.ToString(), stage.stageObject);
        }
    }

    public void SkipToStage(Mission01StageLabel s)
    {
        foreach (Mission01Stage stage in stageList)
        {
            if (stage.stageLabel == s)
            {
                Advance(s.ToString());



                PlayerCharacter.Instance.GetComponent<CharacterController>().enabled = false;
                PlayerCharacter.Instance.transform.position = stage.stageObject.GetStageStartPos().transform.position;
                PlayerCharacter.Instance.GetComponent<CharacterController>().enabled = true;

                return;
            } else
            {
                stage.stageObject.SkipAndSatisfyAllRequirements();
            }
        }
    }

    protected override void OnPassThroughTriggered(string id)
    {
        string LeftBathroomTrigger = "LeftBathroomTrigger";
        string LeftRoomTrigger = "LeftRoomTrigger";
        string EnteredStockRoomTrigger = "EnteredStockRoomTrigger";
        string EnteredHatmanHallTrigger = "EnteredHatmanHallTrigger";

        if (currentStage == Mission01StageLabel.LeftBathroom.ToString() && id == LeftBathroomTrigger)
        {
            Advance(Mission01StageLabel.LeftRoom.ToString());
        } else if (currentStage == Mission01StageLabel.LeftRoom.ToString()  && id == LeftRoomTrigger)
        {
            Advance(Mission01StageLabel.TalkedToMaeby.ToString());
        }
        else if (currentStage == Mission01StageLabel.EnteredStockRoom.ToString() && id == EnteredStockRoomTrigger)
        {
            Advance(Mission01StageLabel.FoundAllPillBottles.ToString());
        }
        else if (currentStage == Mission01StageLabel.EnteredHatmanHall.ToString() && id == EnteredHatmanHallTrigger)
        {
            Advance(Mission01StageLabel.FoundBeatbox.ToString());
        }
    }

    protected override void OnPickupCollected(string id)
    {
        string KeycardPickup = "KeycardPickup";
        string BarkadrylPickup = "BarkadrylPickup";

        if (currentStage == Mission01StageLabel.FoundKeycard.ToString() && id == KeycardPickup)
        {
            Advance(Mission01StageLabel.EnteredStockRoom.ToString());
        }

        if (currentStage == Mission01StageLabel.FoundAllPillBottles.ToString() && id == BarkadrylPickup)
        {
            barkadrylCount++;
            if (barkadrylCount >= 2)
            {
                Advance(Mission01StageLabel.ConsumedPills.ToString());
            }
        }

        
        //would be here, foundallpillbottles
    }

    protected override void OnSequenceCompleted(string id)
    {
        string ConsumedBarkadrylProperlyEvent = "ConsumedBarkadrylProperlyEvent";

        if (currentStage == Mission01StageLabel.ConsumedPills.ToString() && id == ConsumedBarkadrylProperlyEvent)
        {
            Advance(Mission01StageLabel.EnteredHatmanHall.ToString());
        }
    }

    protected override void OnTapEventFinished(string id)
    {
        string TalkedToMaebyEvent = "TalkedToMaebyEvent";
        string TappedPseudoBeatboxPickup = "TappedPseudoBeatboxPickup";

        if (currentStage == Mission01StageLabel.TalkedToMaeby.ToString() && id == TalkedToMaebyEvent)
        {
            Advance(Mission01StageLabel.FoundKeycard.ToString());
        }

        if (currentStage == Mission01StageLabel.FoundBeatbox.ToString() && id == TappedPseudoBeatboxPickup)
        {
            Advance(Mission01StageLabel.CompletedBeatTutorial.ToString());
           // Debug.Log("wow");
        }

    }
}

public enum Mission01StageLabel { 
    NotStarted,
    LeftBathroom,
    LeftRoom,
    TalkedToMaeby,
    FoundKeycard,
    EnteredStockRoom,
    FoundAllPillBottles,
    ConsumedPills,
    EnteredHatmanHall,
    FoundBeatbox,
    CompletedBeatTutorial,
    MetHatman,
    CompletedHatmanBeatGame,
    /*
     * 
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
    public MissionStage stageObject;
}
