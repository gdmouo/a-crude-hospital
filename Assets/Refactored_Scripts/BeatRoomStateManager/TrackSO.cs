using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tracks/TrackSO")]
public class TrackSO : ScriptableObject
{
    public TrackTitle Title;
    public List<Beats> BeatMapping;
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
    public KeyControlling Target;
    //0 for non longbeat
    public double LongBeatDuration;
}

[System.Serializable]
public struct Beats {
    public float ArrivalTimeInTrack;
    public List<Beat> BeatsToMap;
}


[System.Serializable]
public struct RecordSettings
{
    public float FlyTime;
    public double TrackStartTime;
    public double TrackEndTime;
    public AudioSource Track;
}


