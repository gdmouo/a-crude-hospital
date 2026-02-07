using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tracks/TrackSO")]
public class TrackSO : ScriptableObject
{
    public TrackTitle Title;
    public List<Beat> Beats;
    public RecordSettings Settings;
}

[System.Serializable]
public enum TrackTitle { 
    NULL,
    Internet_Connection
}

[System.Serializable]
public struct Beat
{
    public float ArrivalTimeInTrack;
    public List<KeyControlling> Targets;
    public Beat(float t, List<KeyControlling> k)
    {
        ArrivalTimeInTrack = t;
        Targets = k;
    }
}

[System.Serializable]
public struct RecordSettings
{
    public float FlyTime;
    public double TrackStartTime;
    public double TrackEndTime;
    public AudioSource Track;
}


