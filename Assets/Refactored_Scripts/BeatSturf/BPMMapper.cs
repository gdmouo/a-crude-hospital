using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BPMMapper : MonoBehaviour
{
    [SerializeField] private List<MappedBeat> customBeats;

    protected TrackSO trackSO;
    protected double bpm;

    protected const double WHOLE_NOTE_DENOM = 1;
    protected const double HALF_NOTE_DENOM = 2;

    
    private void Start()
    {
        Track t = GetComponent<Track>();
        trackSO = t.GetTrackSO();
        bpm = trackSO.BPM;
        SetTrackSOMap(trackSO);
    }

    private void SetTrackSOMap(TrackSO tSO)
    {
        List<MappedBeat> beatMap = new List<MappedBeat>();
        beatMap.AddRange(MapBeatsWithBPM(bpm, trackSO));

        if (customBeats != null)
        {
            beatMap.AddRange(customBeats);
        }

        beatMap.Sort((a, b) => a.GetArrivalTime().CompareTo(b.GetArrivalTime()));
        tSO.BeatMapping = beatMap;
    }

    public abstract List<MappedBeat> MapBeatsWithBPM(double BPM, TrackSO tSO);
    
    protected List<MappedBeat> MapByNoteType(double secondsBetweenBeat, double noteTypeDenominator, double startTime, double endTime, PadLabel key, double flyTime)
    {
        List<MappedBeat> mappedBeats = new List<MappedBeat>();
        double noteTypeInterval = secondsBetweenBeat / noteTypeDenominator;

        int i = 1;
        for (; ; i++)
        {
            double t = startTime + i * noteTypeInterval;

            if (t >= endTime) break;

            double shootTime = t - flyTime;

            if (shootTime >= startTime)
            {

                MappedBeat mappedBeat = new MappedBeat();

                mappedBeat.ArrivalTimeInTrack = GetSecondsAsTimeVector(t);
                mappedBeat.TargetKey = key;

                mappedBeats.Add(mappedBeat);
            }
        }

        return mappedBeats;
    }

    protected Vector3 GetSecondsAsTimeVector(double d)
    {
        double decimalPart = (d - Math.Floor(d)) * 100;
        decimalPart = Math.Truncate(decimalPart);
        double minutes = Math.Floor(d / 60);
        minutes = Math.Truncate(minutes);
        double seconds = d % 60;
        seconds = Math.Truncate(seconds);

        Vector3 temp = new Vector3((float) minutes, (float) seconds, (float) decimalPart);
        Debug.Log(temp);
        return temp;
    }
}