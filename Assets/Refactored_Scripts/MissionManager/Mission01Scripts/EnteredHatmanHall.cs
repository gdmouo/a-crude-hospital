using System.Collections.Generic;
using UnityEngine;

public class EnteredHatmanHall : MissionStage
{
    [SerializeField] private List<GameObject> toActivate;
    [SerializeField] private List<GameObject> toDeactivate;
    public override void ToInvoke()
    {
        UpdateObjective();
        foreach (GameObject obk in toActivate)
        {
            obk.SetActive(true);
        }
        foreach (GameObject obk in toDeactivate)
        {
            obk.SetActive(false);
        }
    }

    public void SatisfyInvoke()
    {
        foreach (GameObject obk in toActivate)
        {
            if (obk != null) {
                obk.SetActive(true);
                }
        }
        foreach (GameObject obk in toDeactivate)
        {
            if (obk != null)
            {
                obk.SetActive(false);
            }
        }
    }
}
