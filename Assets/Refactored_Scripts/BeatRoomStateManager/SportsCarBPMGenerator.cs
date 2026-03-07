using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportsCarBPMGenerator : BPMMapper
{
    public override List<MappedBeat> MapBeatsWithBPM(double BPM, TrackSO tSO)
    {
        double SPM = 60;
        double secondsBetweenBeat = SPM / BPM;
        List<MappedBeat> mappedBeats = new List<MappedBeat>();

        double thisEndTime = 5;
        double nextEndTime = 10;
        //  mappedBeats.AddRange(MapByNoteType(secondsBetweenBeat, WHOLE_NOTE_DENOM, tSO.GetStartTime(), tSO.GetEndTime(), KeyControlling.LEFT_ARR, tSO.BeatFlyDuration));
        mappedBeats.AddRange(MapByNoteType(secondsBetweenBeat, WHOLE_NOTE_DENOM, tSO.GetStartTime(), thisEndTime, KeyControlling.LEFT_ARR, tSO.BeatFlyDuration));
        mappedBeats.AddRange(MapByNoteType(secondsBetweenBeat, HALF_NOTE_DENOM, thisEndTime, nextEndTime, KeyControlling.A_KEY, tSO.BeatFlyDuration));
        
        return mappedBeats;
    }
}
