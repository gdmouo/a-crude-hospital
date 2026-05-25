using System;
using System.Collections.Generic;
using UnityEngine;

public class SongStageRunner : MonoBehaviour
{
    [SerializeField] private DSPClock dspClock;
    [SerializeField] private SongManager songManager;
    [SerializeField] private SongTitle songQueued;
    [SerializeField] private BeatSpawnerManager beatManager;

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
        PlayAudio(currentSong.GetAudioSource(), currentSong.GetStartTime(), currentSong.GetIntroDelay());
        playing = true;
    }

    private List<Note> currentSongBeatMap;
    private int currentSongBeatMapCount = 0;

    private void ProgressSong()
    {
        if (dspClock == null) return;

        double songDSP = dspClock.GetAudioDSP();

        Debug.Log(songDSP);

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

            //break exits the while lloop thats why it works
            if (songDSP < trackShootTime) break;
            beatManager.PlayBeat(n);

            songBeatMapIndex++;
        }
    }
    private void PlayAudio(AudioSource a, double startTime, double introDelay)
    {
        a.time = (float) startTime;
        double dspStart = AudioSettings.dspTime;
        a.PlayScheduled(dspStart + Math.Abs(introDelay));

        //dspstart + delay
        //delay should be negatibve
        //
        dspClock.SetAudioDSP(startTime - introDelay);
    }
}
