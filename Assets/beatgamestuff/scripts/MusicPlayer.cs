using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.Rendering.DebugUI;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private SongBeatMap songBeatMap;
    private AudioSource song;
    private int nextIndex = 0;
    private double songStartTime;
    private List<ProjBeat> noteBeats;

    private double songEndTime;

    private bool songStarted = false;

   // public float timeElapsed { get; private set; }

    private void Awake()
    {
       // timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (songStarted)
        {
            RunSong();
        }
    }


    public void StartSong()
    {
        if (songBeatMap != null)
        {
            BeatList b = songBeatMap.GetBeatMap();
            noteBeats = b.beatList;
            song = songBeatMap.GetSong();

            //upodate score manager
            ScoreManager.Instance.SetupScoreManager(b.maxScore);
            

            TrackSO trackSO = songBeatMap.GetTrackSO();
            songStartTime = AudioSettings.dspTime + trackSO.songStartTime;
            songEndTime = trackSO.songEndTime;

            TimeManager.Instance.SetupTimeManager((float) trackSO.songEndTime);
        } else
        {
            Debug.LogError("SONG BEAT MAP UNASSIGNED");
            return;
        }

        songStartTime = AudioSettings.dspTime + 0.1;
        song.PlayScheduled(songStartTime);
        songStarted = true;
    }

    private void RunSong()
    {
        double songTime = AudioSettings.dspTime - songStartTime;
        //timeElapsed = (float) songTime;

        if (TimeManager.Instance.timeInitialized)
        {
            TimeManager.Instance.UpdateTime(Math.Round(songTime, 2));
        }

        

        if (songTime < 0)
        {
            return;
        } else if (songTime >= songEndTime)
        {
            StopSong();
            return;
        }

        if (nextIndex < noteBeats.Count)
        {
            ProjBeat pB = noteBeats[nextIndex];

            double spawnTime = pB.time;
            if (songTime >= spawnTime)
            {
                SpawnNote(pB);
                nextIndex++;
            }
        }

    }

    private void SpawnNote(ProjBeat pB)
    {
        if (AttackController.Instance.PLDict.TryGetValue(pB.dir, out ProjectileLauncher pL)) {
            pL.FireProjectile(pB.time);
        }
    }

    private void StopSong()
    {
        songStarted = false;
        song.Stop();
    }
}

[System.Serializable]
public struct ProjBeat
{
    public float time;
    public Dir dir;
    public ProjBeat(float f, Dir d)
    {
        time = f;
        dir = d;
    }
}
