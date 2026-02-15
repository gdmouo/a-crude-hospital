using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMMapper : MonoBehaviour
{
   // [Header("TrackInfo")]
    private TrackSO trackSO;
    private double bpm;

    private const double WHOLE_NOTE_DENOM = 1;

    
    private void Start()
    {
        Track t = GetComponent<Track>();
        trackSO = t.GetTrackSO();
            //GetComponent<TrackSO>();
        bpm = trackSO.BPM;
        SetTrackSOMap(trackSO);
        //
       // secondsBetweenBeat = SPM / bpm;
        //(int)System.Math.Floor(songTime / secondsPerBeat);
    }

    private void SetTrackSOMap(TrackSO tSO)
    {
        tSO.BeatMapping = MapBeatsWithBPM(bpm, trackSO);
    }

    public List<MappedBeat> MapBeatsWithBPM(double BPM, TrackSO tSO)
    {
        double SPM = 60;
        double secondsBetweenBeat = SPM / BPM;
        List<MappedBeat> mappedBeats = new List<MappedBeat>();

        mappedBeats.AddRange(MapByNoteType(secondsBetweenBeat, WHOLE_NOTE_DENOM, tSO.GetStartTime(), tSO.GetEndTime(), KeyControlling.LEFT_ARR));

        return mappedBeats;
    }

    //struct with duration, keycontrolling, and perhaps ntoeType

    public List<MappedBeat> MapByNoteType(double secondsBetweenBeat, double noteTypeDenominator, double startTime, double endTime, KeyControlling key)
    {
        List<MappedBeat> mappedBeats = new List<MappedBeat>();
        double currTime;
        double noteTypeInterval = secondsBetweenBeat / noteTypeDenominator;


        for (currTime = startTime; currTime < endTime; currTime += noteTypeInterval)
        {
            MappedBeat mappedBeat = new MappedBeat();
            mappedBeat.ArrTimeAsDouble = currTime;
            mappedBeat.TargetKey = key;

            mappedBeats.Add(mappedBeat);
        }

        return mappedBeats;
    }

    //subdivide, secondsBetweenBeat / (2,4,3 for 8th, 16th, triplet notes)

}

/*
using UnityEngine;
using System;

public class Conductor : MonoBehaviour
{
    [Header("Song")]
    public AudioSource music;
    public double bpm = 120.0;
    public double songOffsetSeconds = 0.0; // use if your clip has silence/lead-in

    public event Action<int, double> OnBeat; 
    // params: beatIndex, beatDspTime

    double secondsPerBeat;
    double songStartDsp;
    int lastBeatIndex = -1;

    void Start()
    {
        secondsPerBeat = 60.0 / bpm;

        // Schedule music start precisely
        songStartDsp = AudioSettings.dspTime + 0.2; // small buffer
        music.PlayScheduled(songStartDsp);
    }

    void Update()
    {
        double dsp = AudioSettings.dspTime;
        double songTime = (dsp - songStartDsp) - songOffsetSeconds;

        if (songTime < 0) return; // not started yet (or offset not reached)

        int beatIndex = (int)System.Math.Floor(songTime / secondsPerBeat);

        if (beatIndex != lastBeatIndex)
        {
            lastBeatIndex = beatIndex;

            // The exact DSP time when this beat occurs:
            double beatTimeInSong = beatIndex * secondsPerBeat;
            double beatDspTime = songStartDsp + songOffsetSeconds + beatTimeInSong;

            OnBeat?.Invoke(beatIndex, beatDspTime);
        }
    }

    public double GetBeatDspTime(int beatIndex)
    {
        return songStartDsp + songOffsetSeconds + (beatIndex * secondsPerBeat);
    }
}

 */