using System.Collections.Generic;
using UnityEngine;

public class FoundBeatbox : MissionStage
{
    [SerializeField] private List<GameObject> toActivate;
    [SerializeField] private HatmanDefeatedManager sequenceRunner;
    [SerializeField] private bool enableHatmanSequence = true;
    public override void ToInvoke()
    {
        UpdateObjective();
        foreach (GameObject go in toActivate)
        {
            go.SetActive(true);
        }
        if (enableHatmanSequence)
        {
            sequenceRunner.Run();
        }
    }
}
