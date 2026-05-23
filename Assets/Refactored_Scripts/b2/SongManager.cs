using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    [SerializeField] private List<Song> songs;

    public Song GetSongByLabel(SongTitle s)
    {
        if (songs == null) return null;

        foreach (Song song in songs)
        {
            if (song.Title == s) return song;
        }

        return null;
    }
}

public enum SongTitle { 
    Beaty,
    Im_gay
}

