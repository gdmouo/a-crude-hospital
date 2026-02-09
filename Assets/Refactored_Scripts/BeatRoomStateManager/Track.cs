using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] private TrackSO trackSO;
    [SerializeField] private AudioSource audioSource;

    public TrackSO SO { get { return trackSO; } }
    public AudioSource Source { get { return audioSource; } }
}
