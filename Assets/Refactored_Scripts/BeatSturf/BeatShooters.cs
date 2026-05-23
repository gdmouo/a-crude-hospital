using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatShooters : MonoBehaviour, IBeatShooter
{
    [SerializeField] private List<BeatShooter> beatShooters;
    [SerializeField] private GameObject beatPrefab;
    [SerializeField] private Transform beatParent;
    [SerializeField] private float beatLifetime;
    [SerializeField] private Vector3 direction;

    private void Start()
    {
        foreach (BeatShooter bShooter in beatShooters)
        {
            Vector3 newPos = new Vector3(bShooter.BeatPadTargetPos.position.x, bShooter.BeatShooterPos.position.y, bShooter.BeatShooterPos.position.z);
            bShooter.BeatShooterPos.position = newPos;
        }
    }

    public void Fire(PadLabel k, double d)
    {
        BeatShooter shooter = GetShooterByKey(k);

        //

        BeatParam beatParam = new BeatParam(shooter.BeatShooterPos.position, shooter.BeatPadTargetPos.position, d);



        GameObject temp = Instantiate(beatPrefab, shooter.BeatShooterPos.position, Quaternion.identity);
        temp.transform.SetParent(beatParent);
        Beat beatComponent = temp.GetComponent<Beat>();
        beatComponent.Init(beatParam, direction);
        Destroy(temp, beatLifetime);
    }

    private BeatShooter GetShooterByKey(PadLabel k)
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
    public PadLabel TargetKey;
    public Transform BeatShooterPos;
    public Transform BeatPadTargetPos;
}


