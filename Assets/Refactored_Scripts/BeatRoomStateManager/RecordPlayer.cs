using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    [SerializeField] private NoteController noteController;
    [SerializeField] private double lead = 0.1;
    private List<Beats> beatMapping;

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

    public void LoadTrack(Track t)
    {
        TrackSO tSO = t.SO;
        AudioSource aS = t.Source;

        List<Beats> trackBeats = tSO.BeatMapping;
        beatMapping = trackBeats;

        RecordSettings rS = tSO.Settings;

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
            Beats beats = beatMapping[nextIndex];
            double spawnTime = Math.Max(beats.GetFloatArrivalTime() - flyTime, 0.0);

            if (trackTime < spawnTime) break;

            SpawnBeats(beats);
            nextIndex++;

            /*
            //

            Beats beats = beatMapping[nextIndex];
            double spawnTime = Mathf.Max(beats.GetFloatArrivalTime() - flyTime, 0);

            if (trackTime >= spawnTime)
            {
                List<Beat> toMap = beats.BeatsToMap;

                if (toMap == null || toMap.Count == 0)
                {
                    return;
                }

                foreach (Beat b in toMap)
                {
                    Debug.Log("fart");
                    SpawnNote(b, flyTime);
                }

                nextIndex++;
            }*/
        }
    }


    private void SpawnBeats(Beats beats)
    {
        List<Beat> toMap = beats.BeatsToMap;

        if (toMap == null || toMap.Count == 0)
        {
            return;
        }

        foreach (Beat b in toMap)
        {
           // Debug.Log("fart");
            SpawnNote(b, flyTime);
        }
    }

    /*
    private void HandleTrack()
    {



        double trackTime = AudioSettings.dspTime - trackStartTime;
       // Debug.Log("trackTime: " + trackTime.ToString());



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
            double spawnTime = Mathf.Max(beats.GetFloatArrivalTime() - flyTime, 0);

  
            if (trackTime >= spawnTime)
            {
                List<Beat> toMap = beats.BeatsToMap;

                if (toMap == null || toMap.Count == 0) {
                    return;
                }

                foreach (Beat b in toMap)
                {
                    Debug.Log("fart");
                    SpawnNote(b, flyTime);
                }

                nextIndex++;
            }
        }

    }*/

    /*
    private void SpawnNote(Beat beat, float f)
    {
        if (noteController == null)
        {
            return;
        }

        if (noteController.NSDict.TryGetValue(beat.Target, out NoteSpawner nSp))
        {
            nSp.FireNote(f, beat.LongBeatDuration, noteController.GetAdjustedNoteSpawnerSettings());
        }
    }*/

    private void SpawnNote(Beat beat, double hitTime)
    {
        if (noteController == null)
        {
            return;
        }

        double spawnTime = hitTime - flyTime;

        if (noteController.NSDict.TryGetValue(beat.Target, out NoteSpawner nSp))
        {
            nSp.FireNote(spawnTime, hitTime, beat.LongBeatDuration, noteController.GetAdjustedNoteSpawnerSettings());
        }
    }


    private void EndTrack()
    {
        trackStarted = false;
        track.Stop();
    }
}
