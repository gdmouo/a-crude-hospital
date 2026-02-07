using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SongBeatMap : MonoBehaviour, ISongBeatMap
{
    [SerializeField] protected FartSO trackSO;
    [SerializeField] private AudioSource song;
    public BeatList GetBeatMap()
    {
        List<ProjBeat> toRet = GenerateBeatMap();
        BeatList b = new BeatList(toRet, toRet.Count * 100f);
        return b;
    }

    public AudioSource GetSong()
    {
        return song;
    }

    public FartSO GetTrackSO()
    {
        return trackSO;
    }

    protected virtual List<ProjBeat> GenerateBeatMap()
    {
        return null;
    }
}

[System.Serializable]
public struct BeatList
{
    public List<ProjBeat> beatList;
    public float maxScore;
    public BeatList(List<ProjBeat> p, float f)
    {
        beatList = p;
        maxScore = f;
    }
}
