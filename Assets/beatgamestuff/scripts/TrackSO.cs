using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Track", menuName = "TrackSO")]
public class TrackSO : ScriptableObject
{
    public string songTitle;
    public float beatSpeed;
    public double songStartTime;
    public double songEndTime;
}
