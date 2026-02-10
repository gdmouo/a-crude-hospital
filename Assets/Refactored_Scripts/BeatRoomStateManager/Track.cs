using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour, ITrack
{
    [SerializeField] private TrackSO trackSO;
    [SerializeField] private AudioSource audioSource;

    public TrackSO GetTrackSO()
    {
        return trackSO;
    }
    public AudioSource GetAudioSource()
    {
        return audioSource;
    }
}


[CreateAssetMenu(menuName = "Tracks/TrackSO")]
public class TrackSO : ScriptableObject
{
    public TrackKey Key;
    public List<MappedBeat> BeatMapping;
    public Vector3 StartTime;
    //public Vector3 EndTime;
    public double BeatFlyDuration;

    public double GetStartTime()
    {
        float minutes = StartTime.x;
        float seconds = StartTime.y;
        float milliseconds = StartTime.z;

        float arrivalTime = 0f;

        arrivalTime += ((minutes * 60f) + seconds + (milliseconds / 60f));

        return arrivalTime;
    }

    /*
    public double GetEndTime()
    {
        float minutes = StartTime.x;
        float seconds = StartTime.y;
        float milliseconds = StartTime.z;

        float arrivalTime = 0f;

        arrivalTime += ((minutes * 60f) + seconds + (milliseconds / 60f));

        return arrivalTime;
    }*/
}

[System.Serializable]
public struct MappedBeat
{
    public Vector3 ArrivalTimeInTrack;
    public KeyControlling TargetKey;
    public double GetArrivalTime()
    {
        float minutes = ArrivalTimeInTrack.x;
        float seconds = ArrivalTimeInTrack.y;
        float milliseconds = ArrivalTimeInTrack.z;

        float arrivalTime = 0f;

        arrivalTime += ((minutes * 60f) + seconds + (milliseconds / 60f));

        return arrivalTime;
    }
}

[System.Serializable]
public enum TrackKey { 
    Track_01
}

