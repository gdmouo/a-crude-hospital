using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldTrack : MonoBehaviour
{
    [SerializeField] private OldTrackSO trackSO;
    [SerializeField] private AudioSource audioSource;

    public OldTrackSO SO { get { return trackSO; } }
    public AudioSource Source { get { return audioSource; } }
}
