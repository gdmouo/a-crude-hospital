using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    [SerializeField] private NoteController noteController;
    private List<Beat> beatMapping;

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
        List<Beat> trackBeats = trackSO.Beats;
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
            Beat beat = beatMapping[nextIndex];

            double spawnTime = Mathf.Max(beat.ArrivalTimeInTrack - flyTime, 0);

            if (trackTime >= spawnTime)
            {
                List<KeyControlling> targets = beat.Targets;

                if (targets == null || targets.Count == 0) {
                    return;
                }

                foreach (KeyControlling k in targets)
                {
                    SpawnNote(k, flyTime);
                }

                nextIndex++;
            }
        }

    }

    private void SpawnNote(KeyControlling target, float f)
    {
        if (noteController == null)
        {
            return;
        }
        //NoteController.Instance;
        if (noteController.NSDict.TryGetValue(target, out NoteSpawner nSp))
        {
            nSp.FireNote(f);
        }
    }

    private void EndTrack()
    {
        trackStarted = false;
        track.Stop();
    }
}
