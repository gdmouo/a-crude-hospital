using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pill", menuName = "PillSO")]
public class PillSO : ScriptableObject
{
    public Sprite sprite;
    public string pillName;
    public string pillDescription;
    public GameObject pillGUIPrefab;
}
