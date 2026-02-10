using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordManager : MonoBehaviour
{
    [SerializeField] private List<OldTrack> tracks;
    [SerializeField] private OldTrackTitle currentTrack;
    [SerializeField] private OldRecordPlayer recordPlayer;

    public void PlayTrack()
    {
        if (recordPlayer != null)
        {
            OldTrack toPlay = GetTrackByTitle(currentTrack);
            if (toPlay != null)
            {
                recordPlayer.LoadTrack(toPlay);
            }
            recordPlayer.StartTrack();
        }
    }

    public OldTrack GetTrackByTitle(OldTrackTitle t)
    {
        if (tracks == null) return null;
        foreach (OldTrack track in tracks)
        {
            if (track.SO.Title == t) return track;
        }
        return null;
    }

   // public void 
}
