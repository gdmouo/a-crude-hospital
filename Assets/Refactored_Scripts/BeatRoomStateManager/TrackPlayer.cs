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
    private double trackStartTime;

    private bool play = false;

    private void Update()
    {
        if (play) HandlePlay();
    }

    public void Play()
    {
        beatMapIndex = 0;
        TrackSO trackSO = track.GetTrackSO();
        beatFlyDuration = trackSO.BeatFlyDuration;
        trackBeatMapping = trackSO.BeatMapping;
        trackStartTime = trackSO.GetStartTime();
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
            //vv get arrivaltime, check if its based on bpm generation and use a different function?
            double trackShootTime = m.GetArrivalTime() - beatFlyDuration;
          //  trackShootTime = Math.Max(trackShootTime, 0);
          //  Debug.Log(trackShootTime);

            /*
            if (trackShootTime < trackStartTime)
            {
                beatMapIndex++;
                break;
            }*/

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
        a.time = (float) startTime;
        double dspStart = AudioSettings.dspTime;
        a.PlayScheduled(dspStart);
        audioTime.RestartClock(startTime);
    }
}
