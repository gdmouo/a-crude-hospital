using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrackMap : MonoBehaviour, ITrackMap
{
    public virtual List<ProjBeat> GetBeatMap()
    {
        Debug.LogError("NOT INITIALIZED YET");
        return null;
    }
}
