using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour
{
    [SerializeField] private TrackSO trackSO;
    public List<Beat> GetBeatMapping() {
        return trackSO.Beats;
    }
    public RecordSettings GetRecordSettings()
    {
        return trackSO.Settings;
    }
}

