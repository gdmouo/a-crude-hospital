using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour, IBeat
{
    private AudioTime audioTime;
    private float movementSpeed;
    private Vector3 direction = Vector3.up;
    private bool shoot = false;

    // Start is called before the first frame update
    private void Start()
    {
        audioTime = AudioTime.Instance;
        if (audioTime == null) return;
    }

    // Update is called once per frame
    private void Update()
    {
        if (shoot) HandleShoot();
    }

    public void HandleShoot()
    {
        if (audioTime == null) return;

        double audioDeltaTime = audioTime.DeltaTime;

        transform.position += (Vector3)(movementSpeed * (float) audioDeltaTime * direction);
    }

    public void Init(BeatParam b)
    {
        movementSpeed = b.GetBeatSpeed();
       // transform.position = b.StartPos;
        shoot = true;
    }
}

[System.Serializable]
public struct BeatParam {
    public Vector3 StartPos;
    public Vector3 EndPos;
    public double TimeToLand;

    public BeatParam(Vector3 s, Vector3 e, double t)
    {
        StartPos = s;
        EndPos = e;
        TimeToLand = t;
    }

    public float GetBeatSpeed()
    {
        float displacement = GetDisplacement();
        return displacement / (float) TimeToLand;
    }

    private float GetDisplacement()
    {
        return Vector3.Distance(StartPos, EndPos);
    }
}