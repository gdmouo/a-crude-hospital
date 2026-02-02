using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissionStageEvent : MonoBehaviour
{
    private void Awake()
    {
        OnAwake();
    }

    private void Start()
    {
        OnStart();
    }
    private void Update()
    {
        OnUpdate();
    }

    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
    public abstract void OnAwake();
    public abstract void OnStart();
    public abstract void OnUpdate();
    public abstract void OnFixedUpdate();

    public abstract void ToInvoke();
}
