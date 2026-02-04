using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissionStage : MonoBehaviour
{
    [SerializeField] protected string objectiveToUpdate;
    public abstract void ToInvoke();
    public void UpdateObjective()
    {
        ObjectiveManager o = ObjectiveManager.Instance;
        if (o != null)
        {
            ObjectiveUI u = o.GetObjectiveUI();
            u.SetBodyOnly(objectiveToUpdate);
        }
    }
    public void UpdateObjective(string t)
    {
        ObjectiveManager o = ObjectiveManager.Instance;
        if (o != null)
        {
            ObjectiveUI u = o.GetObjectiveUI();
            u.SetBodyOnly(t);
        }
    }
}
