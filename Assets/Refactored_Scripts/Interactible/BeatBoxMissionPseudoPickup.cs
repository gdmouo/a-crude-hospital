using System;
using UnityEngine;

public class BeatBoxMissionPseudoPickup : MissionTap
{

    protected override void OnInteract(Action a)
    {
        OnInteractEventFinished();
        //
        //  SceneSet s = SceneSet.Instance;
         PersistentManager.Instance.SetMissionStageForReturn(Mission01StageLabel.MetHatman);
       PersistentManager.Instance.LoadBeatLevel(SongTitle.Beaty);
       // PersistentManager.Instance.LoadMission();
        PersistentManager.Instance.SwitchRoom();

        Destroy(gameObject);
    }

    /*
    public override string GetName()
    {
        return 
    }*/
}
