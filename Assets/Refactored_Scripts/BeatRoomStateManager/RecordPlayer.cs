using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    [SerializeField] private NoteController noteController;
    private List<Beats> beatMapping;

    private AudioSource track;
    private float flyTime;
    private double trackStartTime;
    private double trackEndTime;

    private int nextIndex = 0;

    private bool trackStarted = false;

    private bool trackLoaded = false;

    private void Awake()
    {
        // timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (trackStarted)
        {
            HandleTrack();
        }
    }

    public void LoadTrack(TrackSO trackSO)
    {
        List<Beats> trackBeats = trackSO.BeatMapping;
        beatMapping = trackBeats;

        RecordSettings rS = trackSO.Settings;

        track = rS.Track;

        trackStartTime = AudioSettings.dspTime + rS.TrackStartTime;
        trackEndTime = AudioSettings.dspTime + rS.TrackEndTime;

        flyTime = rS.FlyTime;

        trackLoaded = true;
    }
    public void StartTrack()
    {
        if (!trackLoaded)
        {
            return;
        }
        nextIndex = 0;

        track.PlayScheduled(trackStartTime);
        trackStarted = true;
    }

    private void HandleTrack()
    {
        double trackTime = AudioSettings.dspTime - trackStartTime;

        if (trackTime < 0)
        {
            return;
        }
        else if (trackTime >= trackEndTime)
        {
            EndTrack();
            return;
        }

        if (nextIndex < beatMapping.Count)
        {
            Beats beats = beatMapping[nextIndex];

            double spawnTime = Mathf.Max(beats.ArrivalTimeInTrack - flyTime, 0);

            if (trackTime >= spawnTime)
            {
                List<Beat> toMap = beats.BeatsToMap;

                if (toMap == null || toMap.Count == 0) {
                    return;
                }

                foreach (Beat b in toMap)
                {
                    SpawnNote(b, flyTime);
                }

                nextIndex++;
            }
        }

    }

    private void SpawnNote(Beat beat, float f)
    {
        if (noteController == null)
        {
            return;
        }

        if (noteController.NSDict.TryGetValue(beat.Target, out NoteSpawner nSp))
        {
            nSp.FireNote(f, beat.LongBeatDuration);
        }
    }

    private void EndTrack()
    {
        trackStarted = false;
        track.Stop();
    }
}
