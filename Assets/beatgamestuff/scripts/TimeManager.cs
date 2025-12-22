using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    private double maxTime;
    private double currentTime;

    public bool timeInitialized { get; private set; }
    public bool songStarted { get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        timeInitialized = false;
        songStarted = false;
    }

    public void SetupTimeManager(float m)
    {
        maxTime = m;
        currentTime = 0f;
        timeInitialized = true;
        songStarted = true;
    }

    public void UpdateTime(double f)
    {
        currentTime = f;
    }

    public double GetCurrentTime()
    {
        return currentTime;
    }

    public double GetMaxTime()
    {
        return maxTime;
    }

}
