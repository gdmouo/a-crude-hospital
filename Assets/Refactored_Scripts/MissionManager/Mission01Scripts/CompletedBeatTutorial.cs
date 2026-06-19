using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedBeatTutorial : MissionStage
{
    [SerializeField] private SceneToGo sceneToGo;
    //  [SerializeField] private List<GameObject> toActivate;
    // [SerializeField] private HatmanDefeatedManager sequenceRunner;
    // [SerializeField] private bool enableHatmanSequence = true;
    public override void ToInvoke()
    {
        UpdateObjective();
        /*
        foreach (GameObject go in toActivate)
        {
            go.SetActive(true);
        }
        if (enableHatmanSequence)
        {
            sequenceRunner.Run();
        }*/

        //

       // SceneSet s = SceneSet.Instance;
       // s.SetMissionStageForReturn(Mission01StageLabel.MetHatman);
       // s.LoadBeatLevel(SongTitle.Beaty);
       // s.SwitchRoom();

    }
}

