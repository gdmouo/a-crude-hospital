using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fart", menuName = "FArtsSO")]
public class FartSO : ScriptableObject
{
    public string songTitle;
    public float flyDuration;
    public double songStartTime;
    public double songEndTime;
    public float passingScore;
}
