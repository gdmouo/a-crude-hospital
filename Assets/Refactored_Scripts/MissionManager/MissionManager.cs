using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private Mission currentMission;

    private void Start()
    {
        if (currentMission != null)
        {
            currentMission.Init();
        }
    }
}

