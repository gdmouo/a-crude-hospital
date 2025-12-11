using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pill : MonoBehaviour
{
    [SerializeField] private PillSO pillSO;
    //private PillBottle bottle;
    public PillSO PillSO { get { return pillSO; } }

    public GameObject GetPillGUIPrefab()
    {
        return pillSO.pillGUIPrefab;
    }

    public void RemovePillFromCase()
    {
        PillcaseUI.Instance.RemovePill(this);
    }
}
