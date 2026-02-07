using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;
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
    private float flyDuration = 1f;

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
            
            

            FartSO trackSO = songBeatMap.GetTrackSO();
            songStartTime = AudioSettings.dspTime + trackSO.songStartTime;
            songEndTime = trackSO.songEndTime;

            flyDuration = trackSO.flyDuration;

            ScoreManager.Instance.SetupScoreManager(b.maxScore, trackSO.passingScore);

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

            double spawnTime = Mathf.Max(pB.time - flyDuration, 0);
            if (songTime >= spawnTime)
            {
                SpawnNote(pB, flyDuration);
                nextIndex++;
            }
        }

    }

    private void SpawnNote(ProjBeat pB, float f)
    {
        if (OldAttackController.Instance.PLDict.TryGetValue(pB.dir, out OldProjectileLauncher pL)) {
            pL.FireProjectile(f);
        }
    }

    private void StopSong()
    {
        songStarted = false;
        song.Stop();
        ResultManager.Instance.EndGame();
        //
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
