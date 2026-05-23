using System;
using System.Collections.Generic;
using UnityEngine;

public class SongComposer : MonoBehaviour
{
    [SerializeField] private Song song;
    [SerializeField] private List<Note> notes;
    [SerializeField] private List<BeatMapCompositionGroup> groups;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (notes == null)
        {
            notes = new List<Note>();
        }


        //

        foreach (BeatMapCompositionGroup b in groups)
        {
            List<Note> parsedGroup = ParseGroup(b);
            notes.AddRange(parsedGroup);
        }

        song.SetBeatMap(notes);
    }

    private List<Note> ParseGroup(BeatMapCompositionGroup b)
    {
        double secondsPerBeat = 60.0 / b.bpm;
        double divider = GetDividerByNoteType(b.noteType);
        return MapByNoteType(secondsPerBeat / divider, b.GetStartTimeAsVec(), b.GetEndTimeAsVec(), (int) divider, b.everyNthNote, b.targetPad);

    }

    private double GetDividerByNoteType(NOTE_TYPE n)
    {
        switch (n) {
            case NOTE_TYPE.WHOLE:
                return 1;
            case NOTE_TYPE.HALF:
                return 2;
            case NOTE_TYPE.QUARTER:
                return 4;
            case NOTE_TYPE.EIGHTH:
                return 8;
            case NOTE_TYPE.SIXTEENTH:
                return 16;
            default:
                return 1;
        }
    }

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
    }
    //public bpm
    //private secondsperbeat
    //private tempBeatTime
    //nextBeatTime += secondsPerBeat;
}

public enum NOTE_TYPE { 
    WHOLE,
    HALF,
    QUARTER,
    EIGHTH,
    SIXTEENTH
}


[System.Serializable]
public struct BeatMapCompositionGroup
{
    [SerializeField] private Vector3 startTimeInTrack;
    [SerializeField] private Vector3 endTimeInTrack;
    public double bpm;
    public NOTE_TYPE noteType;
    public int everyNthNote;
    public PadLabel targetPad;

    public double GetStartTimeAsVec()
    {
        return VecTimeToDouble(startTimeInTrack);
    }
    public double GetEndTimeAsVec()
    {
        return VecTimeToDouble(endTimeInTrack);
    }
    private double VecTimeToDouble(Vector3 v)
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

    //whole, half, quarter, eighth, sixteenth
    //every __th note
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
        return VecTimeToDouble(arrivalTimeInTrack) - beatFlyTime;
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
        arrivalTimeInTrack = GetSecondsAsTimeVector(d);
        //
    }

    public BeatProjectileType GetProjectileType() { return projectileType; }
    private double VecTimeToDouble(Vector3 v)
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
    private Vector3 GetSecondsAsTimeVector(double d)
    {
        double decimalPart = (d - Math.Floor(d));
        int firstTwoDecimals = (int)(decimalPart * 100) % 100;

        d = Math.Floor(d);

        //^pure seconds

        double seconds = d % 60;

        d = d - (d % 60);

        //^ rounded to the nearest wholly divisible by 60

        double minutes = d / 60;

        Vector3 temp = new Vector3((float)minutes, (float)seconds, (float)firstTwoDecimals);

        return temp; 

        /*

        ///
        double decimalPart = (d - Math.Floor(d));
       // decimalPart = Math.Truncate(decimalPart);

        //
       // double value = 0.999;

        int firstTwoDecimals = (int)(decimalPart * 100) % 100;


        //

        double minutes = Math.Floor(d / 60);


        minutes = Math.Truncate(minutes);


        double seconds = d % 60;


        seconds = Math.Truncate(seconds);

        Vector3 temp = new Vector3((float)minutes, (float)seconds, (float)firstTwoDecimals);
      //  Debug.Log(temp);
        return temp;*/
    }
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
    D_KEY
}

public enum BeatProjectileType { 
    Default,
    Long
}
