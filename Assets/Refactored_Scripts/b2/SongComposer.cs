using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SongComposer : MonoBehaviour
{
    [SerializeField] private Song song;
    [SerializeField] private List<Note> notes;
    [SerializeField] private List<BPMSyncedNotes> groups;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (notes == null)
        {
            notes = new List<Note>();
        }

        foreach (BPMSyncedNotes b in groups)
        {
            List<Note> parsedGroup = ParseGroup(b);
            notes.AddRange(parsedGroup);
        }

        song.SetBeatMap(notes);
    }

    private List<Note> ParseGroup(BPMSyncedNotes b)
    {
        return BPMMap(b);
       // double divider = GetDividerByNoteType(b.noteType);
       // return MapByNoteType(secondsPerBeat / divider, b.GetStartTimeAsVec(), b.GetEndTimeAsVec(), (int) divider, b.everyNthNote, b.targetPad);

    }

    /*
    protected List<Note> MapByNoteType(double secondsBetweenBeat, double startTime, double endTime, int noteTypeDivider, int nthBeat, PadLabel key)
    {
        List<Note> mappedBeats = new List<Note>();

        int i = 1;

        double currTime = startTime;

        for (; ; i++)
        {
            for (int y = 0; y < noteTypeDivider; y++)
            {
                if (y == nthBeat)
                {
                    Note n = new Note();
                    n.SetProjectileType(BeatProjectileType.Default);
                    n.SetTargetPad(key);
                    n.SetArrivalTime(currTime);


                    mappedBeats.Add(n);
                }
                currTime += secondsBetweenBeat;
            }

            if (currTime >= endTime) break;
        }

        return mappedBeats;
    }*/

    //how many beats in a bar
    //how many notes in a beat
    protected List<Note> BPMMap(BPMSyncedNotes b)
    {
        List<Note> mappedBeats = new List<Note>();

        int i = 1;

        double secondsPerBeat = 60.0 / b.bpm;
        double currTime = b.GetStartTimeAsDouble();
        double endTime = b.GetEndTimeAsDouble();
        // int notesInABeat = b.notesInABeat;
        // int everyNthNoteInABeat = b.everyNthNoteInABeat;
        // int beatsInABar = b.beatsInABar;
        // int everyNthBeatInABar = b.everyNthBeatInABar;
        // PadLabel p = b.targetPad;

        double secondsBetweenBeat = secondsPerBeat;
        if (b.intervalShortener != 0)
        {
            secondsBetweenBeat = secondsPerBeat / b.intervalShortener;
        }

        
            // notesInABeat;
    //    Debug.Log(notesInABeat);

       // Debug.Log(secondsPerBeat);
      //  Debug.Log(secondsBetweenBeat);
      //  Debug.Log(currTime);
     //   Debug.Log(endTime);

        List<PadLabel> sequence = b.sequence;
        int y = 0;
        int sequenceMax = sequence.Count;

        
        for (; ; i++)
        {
            Note n = new Note();
            n.SetProjectileType(BeatProjectileType.Default);


            n.SetTargetPad(sequence[y]);

            y++;

            if (y == sequenceMax)
            {
                y = 0;
            }


            n.SetArrivalTime(currTime);
            mappedBeats.Add(n);
            /*
            for (int y = 0; y < notesInABeat; y++)
            {
                if (y == everyNthNoteInABeat)
                {
                    Note n = new Note();
                    n.SetProjectileType(BeatProjectileType.Default);
                    n.SetTargetPad(p);
                    n.SetArrivalTime(currTime);

                    mappedBeats.Add(n);
                }
                currTime += secondsBetweenBeat;
            }*/

            currTime += secondsBetweenBeat;

            if (currTime >= endTime) break;
        }

        return mappedBeats;
    }
}

[System.Serializable]
public struct BPMSyncedNotes
{
    [SerializeField] private Vector3 startTimeInTrack;
    [SerializeField] private Vector3 endTimeInTrack;
    public List<PadLabel> sequence;
    public double bpm;
    public int intervalShortener;
   // public PadLabel targetPad;

    //public int notesInABeat;
   // public int everyNthNoteInABeat;
    //public int beatsInABar;
    //public int everyNthBeatInABar;

    public double GetStartTimeAsDouble()
    {
        VectorDoubleConvert v = new VectorDoubleConvert();
        return v.VecTimeToDouble(startTimeInTrack);
    }
    public double GetEndTimeAsDouble()
    {
        VectorDoubleConvert v = new VectorDoubleConvert();
        return v.VecTimeToDouble(endTimeInTrack);
    }
}


[System.Serializable]
public struct Note
{
    [SerializeField] private Vector3 arrivalTimeInTrack;
    [SerializeField] private PadLabel targetPad;
    [SerializeField] private BeatProjectileType projectileType;
    [SerializeField] private double longBeatDuration;
    public PadLabel TargetPad { get { return targetPad; } }
    private double beatFlyTime;
    public double GetBeatArrivalTime()
    {
        VectorDoubleConvert v = new VectorDoubleConvert();
        return v.VecTimeToDouble(arrivalTimeInTrack) - beatFlyTime;
    }

    public void SetBeatFlyTime(double d)
    {
        beatFlyTime = d;
    }

    public double GetBeatFlyTime() { 
        return beatFlyTime; 
    }

    public void SetTargetPad(PadLabel p)
    {
        targetPad = p;
    }

    public void SetProjectileType(BeatProjectileType b)
    {
        projectileType = b;
    }

    public void SetArrivalTime(double d)
    {
        VectorDoubleConvert v = new VectorDoubleConvert();
        arrivalTimeInTrack = v.GetSecondsAsTimeVector(d);
        //
    }

    public BeatProjectileType GetProjectileType() { return projectileType; }
}
public enum PadLabel
{
    UP_ARR,
    DOWN_ARR,
    LEFT_ARR,
    RIGHT_ARR,
    W_KEY,
    A_KEY,
    S_KEY,
    D_KEY,
    NONE
}

public enum BeatProjectileType { 
    Default,
    Long
}

public class VectorDoubleConvert { 
    public VectorDoubleConvert() { }
    public double VecTimeToDouble(Vector3 v)
    {
        double minutes = v.x;


        double seconds = v.y;
        seconds = Math.Min(seconds, 59.0);


        double milliseconds = v.z;
        milliseconds = Math.Min(milliseconds, 99);


        double doubleTime = 0f;

        doubleTime += ((minutes * 60.0) + seconds + (milliseconds / 100.0));

        return doubleTime;
    }
    public Vector3 GetSecondsAsTimeVector(double d)
    {
        double decimalPart = (d - Math.Floor(d));
        int firstTwoDecimals = (int)(decimalPart * 100) % 100;

        d = Math.Floor(d);

        double seconds = d % 60;

        d = d - (d % 60);

        double minutes = d / 60;

        Vector3 temp = new Vector3((float)minutes, (float)seconds, (float)firstTwoDecimals);

        return temp;
    }
}
