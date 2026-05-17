using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Mission : MonoBehaviour, IMission
{
    protected string currentStage;
    protected Dictionary<string, MissionStage> stageStartFunctions;

    public abstract void Init();
    public void Advance(string next)
    {
        if (stageStartFunctions == null)
        {
            return;
        }

        currentStage = next;

        if (stageStartFunctions.TryGetValue(next, out MissionStage missionStage))
        {
            missionStage.ToInvoke();
        }
    }

    private void OnEnable()
    {
        MissionEvents.PassThroughTriggered += OnPassThroughTriggered;
        MissionEvents.PickupCollected += OnPickupCollected;
        MissionEvents.TapEventFinished += OnTapEventFinished;
        MissionEvents.SequenceCompleted += OnSequenceCompleted;
    }

    private void OnDisable()
    {
        MissionEvents.PassThroughTriggered -= OnPassThroughTriggered;
        MissionEvents.PickupCollected -= OnPickupCollected;
        MissionEvents.TapEventFinished -= OnTapEventFinished;
        MissionEvents.SequenceCompleted -= OnSequenceCompleted;
    }

    protected abstract void OnPassThroughTriggered(string id);

    protected abstract void OnTapEventFinished(string id);

    protected abstract void OnPickupCollected(string id);

    protected abstract void OnSequenceCompleted(string id);
}

public static class MissionEvents
{
    public static event Action<string> PassThroughTriggered;
    public static event Action<string> PickupCollected;
    public static event Action<string> TapEventFinished;
    public static event Action<string> SequenceCompleted;

    public static void RaisePassThroughTriggered(string id) => PassThroughTriggered?.Invoke(id);
    public static void RaisePickupCollected(string id) => PickupCollected?.Invoke(id);
    public static void RaiseTapEventFinished(string id) => TapEventFinished?.Invoke(id);

    public static void RaiseSequenceCompleted(string id) => SequenceCompleted?.Invoke(id);
}