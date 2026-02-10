using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour, ITrackPlayer
{
    [SerializeField] private Track track;
    [SerializeField] private AudioTime audioTime;
    [SerializeField] private BeatShooters beatShooters;


    private List<MappedBeat> trackBeatMapping;
    private int beatMapIndex = 0;
    private double beatFlyDuration = 0;

    private bool play = false;

    private void Update()
    {
        if (play) HandlePlay();
    }

    public void Play()
    {
        TrackSO trackSO = track.GetTrackSO();
        beatFlyDuration = trackSO.BeatFlyDuration;
        PlayAudio(track.GetAudioSource(), trackSO.GetStartTime());
        play = true;
    }

    public void HandlePlay()
    {
        if (audioTime == null) return;

        double elapsedTrackSeconds = audioTime.GetAudioClock();

        while (beatMapIndex < trackBeatMapping.Count)
        {
            MappedBeat m = trackBeatMapping[beatMapIndex];
            double trackShootTime = m.GetArrivalTime() - beatFlyDuration;
            trackShootTime = Math.Max(trackShootTime, 0);

            if (elapsedTrackSeconds < trackShootTime) break;

            beatShooters.Fire(m.TargetKey, beatFlyDuration);
            beatMapIndex++;
        }
    }

    private void PlayAudio(AudioSource a, double startTime)
    {
        if (audioTime == null)
        {
            audioTime = AudioTime.Instance;
        }
        double dspStart = AudioSettings.dspTime + startTime;
        a.PlayScheduled(dspStart);
        audioTime.RestartClock(0);
    }
}
