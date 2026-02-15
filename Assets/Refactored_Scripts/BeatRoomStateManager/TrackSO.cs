using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tracks/TrackSO")]
public class TrackSO : ScriptableObject
{
    public TrackKey Key;
    public List<MappedBeat> BeatMapping;
    public Vector3 StartTime;
    public Vector3 EndTime;
    public double BeatFlyDuration;
    public double BPM;

    public double GetStartTime()
    {
        float minutes = StartTime.x;
        float seconds = StartTime.y;
        float milliseconds = StartTime.z;

        float arrivalTime = 0f;

        arrivalTime += ((minutes * 60f) + seconds + (milliseconds / 60f));

        return arrivalTime;
    }

    public double GetEndTime()
    {
        float minutes = EndTime.x;
        float seconds = EndTime.y;
        float milliseconds = EndTime.z;

        float arrivalTime = 0f;

        arrivalTime += ((minutes * 60f) + seconds + (milliseconds / 60f));

        return arrivalTime;
    }
}