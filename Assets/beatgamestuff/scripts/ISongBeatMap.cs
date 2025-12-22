using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISongBeatMap
{
    public BeatList GetBeatMap();
    public AudioSource GetSong();
    public TrackSO GetTrackSO();
}
