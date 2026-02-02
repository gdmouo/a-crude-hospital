using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mission : MonoBehaviour, IMission
{
    [SerializeField] protected string currentStage;
    protected Dictionary<string, Action> stageStartFunctions;

    public abstract void Init();
    public void Advance(string next)
    {
        currentStage = next;

        if (stageStartFunctions.TryGetValue(next, out Action action))
        {
            action?.Invoke();
        }
    }

    private void OnEnable()
    {
        MissionEvents.PassThroughTriggered += OnPassThroughTriggered;
        MissionEvents.PickupCollected += OnPickupCollected;
        MissionEvents.TapEventFinished += OnTapEventFinished;
    }

    private void OnDisable()
    {
        MissionEvents.PassThroughTriggered -= OnPassThroughTriggered;
        MissionEvents.PickupCollected -= OnPickupCollected;
        MissionEvents.TapEventFinished -= OnTapEventFinished;
    }

    protected abstract void OnPassThroughTriggered(string id);

    protected abstract void OnTapEventFinished(string id);

    protected abstract void OnPickupCollected(string id);
}

public static class MissionEvents
{
    public static event Action<string> PassThroughTriggered;
    public static event Action<string> PickupCollected;
    public static event Action<string> TapEventFinished;

    public static void RaisePassThroughTriggered(string id) => PassThroughTriggered?.Invoke(id);
    public static void RaisePickupCollected(string id) => PickupCollected?.Invoke(id);
    public static void RaiseTapEventFinished(string id) => TapEventFinished?.Invoke(id);
}