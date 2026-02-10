using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrack
{
    public TrackSO GetTrackSO();
    public AudioSource GetAudioSource();
}
