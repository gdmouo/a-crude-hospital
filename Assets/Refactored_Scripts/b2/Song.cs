using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{
    [SerializeField] private SongTitle title;
    [SerializeField] private double beatFlyTime;
    private List<Note> beatMap;
    [SerializeField] private double startTime;
    [SerializeField] private AudioSource audioSource;
    public SongTitle Title { get { return title; } }

    public void SetBeatMap(List<Note> m)
    {
        beatMap = m;
    }

    public List<Note> GetBeatMap()
    {
        if (beatMap == null)
        {
            Debug.LogError("BEAT MAP NOT SET");
        }
        /*

        foreach (Note n in beatMap)
        {
            n.SetBeatFlyTime(beatFlyTime);
            Debug.Log(beatFlyTime);
            Debug.Log("Setting");
        }*/

        for (int i = 0; i < beatMap.Count; i++)
        {
            Note n = beatMap[i];
            n.SetBeatFlyTime(beatFlyTime);
            beatMap[i] = n; // write modified struct back
        }

        beatMap.Sort((a, b) => a.GetBeatArrivalTime().CompareTo(b.GetBeatArrivalTime()));
        return beatMap;
    }

    public double GetStartTime()
    {
        return startTime;
    }

    public AudioSource GetAudioSource()
    {
        return audioSource;
    }
}