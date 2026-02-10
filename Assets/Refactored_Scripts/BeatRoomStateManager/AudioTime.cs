using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTime : MonoBehaviour
{

    private double previousTime = double.NaN;
    private double currentTime;

    private double deltaTime = 0;

    private double currAudioTime = 0;

    public static AudioTime Instance { get; private set; }
    public double DeltaTime { get { return deltaTime; } }


    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime = AudioSettings.dspTime;

        if (previousTime != double.NaN)
        {
            deltaTime = currentTime - previousTime;
            currAudioTime += deltaTime;
        }

        previousTime = currentTime;
    }

    public void RestartClock(double offset)
    {
        currAudioTime = offset;
    }

    public double GetAudioClock()
    {
        return currAudioTime;
    }
}
