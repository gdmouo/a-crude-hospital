using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    [SerializeField] private List<Track> tracks;
    [SerializeField] private TrackTitle currentTrack;
    [SerializeField] private RecordPlayer recordPlayer;

    public void PlayTrack()
    {
        if (recordPlayer != null)
        {
            Track toPlay = GetTrackByTitle(currentTrack);
            if (toPlay != null)
            {
                recordPlayer.LoadTrack(toPlay);
            }
            recordPlayer.StartTrack();
        }
    }

    public Track GetTrackByTitle(TrackTitle t)
    {
        if (tracks == null) return null;
        foreach (Track track in tracks)
        {
            if (track.SO.Title == t) return track;
        }
        return null;
    }

   // public void 
}
