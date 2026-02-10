using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class OldRecordPlayer : MonoBehaviour
{
    [SerializeField] private OldNoteController noteController;
    [SerializeField] private double lead = 0.1;
    private List<OldBeats> beatMapping;

    private AudioSource track;
    private float flyTime;
    private double trackStartTime;
    private double trackEndTime;

    private double trackStartOffset;
    private double trackEndOffset;

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

    public void LoadTrack(OldTrack t)
    {
        OldTrackSO tSO = t.SO;
        AudioSource aS = t.Source;

        List<OldBeats> trackBeats = tSO.BeatMapping;
        beatMapping = trackBeats;

        OldRecordSettings rS = tSO.Settings;

        track = aS;

        trackStartOffset = rS.TrackStartTime;
        trackEndOffset = rS.TrackEndTime;

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

        double dspNow = AudioSettings.dspTime;
        double dspStart = dspNow + trackStartOffset + lead;
        double dspEnd = dspNow + trackEndOffset + lead;
        trackStartTime = dspStart;
        trackEndTime = dspEnd;
        track.PlayScheduled(dspStart);
        trackStarted = true;
    }


    private void HandleTrack()
    {
        double trackTime = AudioSettings.dspTime - trackStartTime;

      //  Debug.Log("trackTime: "trackTime);

        if (trackTime < 0)
        {
            return;
        }
        else if (trackTime >= trackEndTime)
        {
            EndTrack();
            return;
        }


        while (nextIndex < beatMapping.Count)
        {
            OldBeats beats = beatMapping[nextIndex];
            double arrivalTime = beats.GetArrivalTime();
            double spawnTime = Math.Max((float) arrivalTime - flyTime, 0.0);

            if (trackTime < spawnTime) break;

            SpawnBeats(beats, spawnTime, arrivalTime);
            nextIndex++;
        }
    }


    private void SpawnBeats(OldBeats beats, double timeAtCall, double timeToHit)
    {
        List<OldBeat> beatsToMap = beats.BeatsToMap;

        if (beatsToMap == null || beatsToMap.Count == 0)
        {
            return;
        }

        foreach (OldBeat beat in beatsToMap)
        {
            if (noteController != null && noteController.NSDict.TryGetValue(beat.Target, out OldNoteSpawner noteSpawner))
            {
                GameObject note = noteSpawner.SpawnGetNote();
                OldNoteSpawnerSettings settings = noteSpawner.GetNoteSpawnerSettings();
                if (note.TryGetComponent<OldNote>(out OldNote nClass))
                {
                    nClass.Init(noteSpawner.transform.position, settings.TargetPad.transform.position, timeAtCall, timeToHit, trackStartTime, flyTime, settings.Direction);

                }


            }
        }
    }


    private void EndTrack()
    {
        trackStarted = false;
        track.Stop();
    }
}
