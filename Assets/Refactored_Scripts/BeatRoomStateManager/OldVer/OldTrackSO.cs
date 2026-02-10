using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "OldTracks/TrackSO")]
public class OldTrackSO : ScriptableObject
{
    public OldTrackTitle Title;
    public List<OldBeats> BeatMapping;
    public OldRecordSettings Settings;
}

[System.Serializable]
public enum OldTrackTitle { 
    NULL,
    Internet_Connection
}

[System.Serializable]
public struct OldBeat
{
    public KeyControlling Target;
    //0 for non longbeat
    public double LongBeatDuration;
}

[System.Serializable]
public struct OldBeats {
    public Vector3 ArrivalTimeInTrack;
    public List<OldBeat> BeatsToMap;
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
public struct OldRecordSettings
{
    public float FlyTime;
    public double TrackStartTime;
    public double TrackEndTime;
}


