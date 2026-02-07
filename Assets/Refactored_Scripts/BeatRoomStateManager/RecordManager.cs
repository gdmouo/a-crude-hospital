using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    [SerializeField] private List<TrackSO> tracks;
    [SerializeField] private TrackTitle currentTrack;
    [SerializeField] private RecordPlayer recordPlayer;
    public void PlayTrack()
    {
        if (recordPlayer != null)
        {
            TrackSO toPlay = GetTrackByTitle(currentTrack);
            if (toPlay != null)
            {
                recordPlayer.LoadTrack(toPlay);
            }
        }
    }

    public TrackSO GetTrackByTitle(TrackTitle t)
    {
        if (tracks == null) return null;
        foreach (TrackSO track in tracks)
        {
            if (track.Title == t) return track;
        }
        return null;
    }

   // public void 
}
