using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatShooters : MonoBehaviour, IBeatShooter
{
    [SerializeField] private List<BeatShooter> beatShooters;
    [SerializeField] private GameObject beatPrefab;
    [SerializeField] private Transform beatParent;
    [SerializeField] private float beatLifetime;

    public void Fire(KeyControlling k, double d)
    {
        BeatShooter shooter = GetShooterByKey(k);
        BeatParam beatParam = new BeatParam(shooter.BeatShooterPos.position, shooter.BeatPadTargetPos.position, d);
        GameObject temp = Instantiate(beatPrefab, shooter.BeatShooterPos.position, Quaternion.identity);
        temp.transform.SetParent(beatParent);
        Beat beatComponent = temp.GetComponent<Beat>();
        beatComponent.Init(beatParam);
        Destroy(temp, beatLifetime);
    }

    private BeatShooter GetShooterByKey(KeyControlling k)
    {
        if (beatShooters == null) throw new System.Exception("erorrrr");

        foreach (BeatShooter beat in beatShooters)
        {
            if (beat.TargetKey == k)
            {
                return beat;
            }
        }

        throw new System.Exception("erorrrr");
    }
}

[System.Serializable]
public struct BeatShooter {
    public KeyControlling TargetKey;
    public Transform BeatShooterPos;
    public Transform BeatPadTargetPos;
}


