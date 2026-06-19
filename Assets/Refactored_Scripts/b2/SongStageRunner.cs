using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongStageRunner : MonoBehaviour
{
    [SerializeField] private DSPClock dspClock;
    [SerializeField] private SongManager songManager;
    [SerializeField] private SongTitle songQueued;
    [SerializeField] private BeatSpawnerManager beatManager;
    [SerializeField] private bool DEBUG_LOG_TIME = true;

    private bool playing = false;

    private int songBeatMapIndex = -1;
    private Song currentSong;

    // Update is called once per frame
    void Update()
    {
        if (playing) ProgressSong();
    }

    public void Play()
    {
        if (playing) return;

        currentSong = songManager.GetSongByLabel(songQueued);
        songBeatMapIndex = 0;
        currentSongBeatMap = currentSong.GetBeatMap();
        currentSongBeatMapCount = currentSongBeatMap.Count;
        PlayAudio(currentSong.GetAudioSource(), currentSong.GetStartTime(), currentSong.GetIntroDelay(), currentSong.GetEndTime());
        playing = true;
    }

    private List<Note> currentSongBeatMap;
    private int currentSongBeatMapCount = 0;

    private void ProgressSong()
    {
        if (dspClock == null) return;

        double songDSP = dspClock.GetAudioDSP();
        double songEndDSP = dspClock.GetAudioEndDSP();

        if (DEBUG_LOG_TIME) Debug.Log(songDSP);

        if (songDSP > songEndDSP)
        {
            EndSong();
            return;
        }
            //call somenedfunc

            while (songBeatMapIndex < currentSongBeatMapCount)
        {
            Note n = currentSongBeatMap[songBeatMapIndex];

            double trackShootTime = n.GetBeatArrivalTime();

            
            if (trackShootTime < currentSong.GetStartTime() - currentSong.GetIntroDelay())
            {
                songBeatMapIndex++;
                break;
            }
            if (n.TargetPad == PadLabel.NONE)
            {
                songBeatMapIndex++;
                break;
            }

            if (songDSP < trackShootTime) break;
            beatManager.PlayBeat(n);

            songBeatMapIndex++;
        }
    }
    private void PlayAudio(AudioSource a, double startTime, double introDelay, double endTime)
    {
        a.time = (float) startTime;
        double dspStart = AudioSettings.dspTime;
        a.PlayScheduled(dspStart + Math.Abs(introDelay));
        dspClock.SetAudioDSP(startTime - introDelay);
        dspClock.SetAudioEndTime(endTime);
    }

    private void EndSong()
    {
      //  SceneToGo s = SceneToGo.Mission_01;
        PersistentManager.Instance.LoadMission();
        PersistentManager.Instance.SwitchRoom();
       // SceneManager.LoadScene(s.ToString());
    }
}
