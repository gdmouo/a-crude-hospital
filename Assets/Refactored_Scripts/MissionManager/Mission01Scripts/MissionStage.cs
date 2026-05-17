using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class MissionStage : MonoBehaviour
{
    [SerializeField] private Transform stageStartPos;
    [SerializeField] protected string objectiveToUpdate;
    [SerializeField] private List<UnityEvent> satisfyingFunctions;
    public abstract void ToInvoke();
    public void UpdateObjective()
    {
        ObjectiveManager o = ObjectiveManager.Instance;
        if (o != null)
        {
            ObjectiveUI u = o.GetObjectiveUI();
            if (!u.IsOpen)
            {
                u.SetOpen(true);
            }
            u.SetBodyOnly(objectiveToUpdate);
        }
    }
    public void UpdateObjective(string t)
    {
        ObjectiveManager o = ObjectiveManager.Instance;
        if (o != null)
        {
            ObjectiveUI u = o.GetObjectiveUI();
            if (!u.IsOpen)
            {
                u.SetOpen(true);
            }
            u.SetBodyOnly(t);
        }
    }

    public Transform GetStageStartPos()
    {
        return stageStartPos;
    }
    public virtual void SkipAndSatisfyAllRequirements()
    {
        if (satisfyingFunctions == null) return;

        foreach (UnityEvent e in satisfyingFunctions)
        {
            e.Invoke();
        }
    }
}
