using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour, IBeat
{
    [SerializeField] private Vector2 projSize;
    private AudioTime audioTime;
    private float movementSpeed;
    private Vector3 direction = Vector3.up;
    private bool shoot = false;

    public Vector2 ProjSize { get { return projSize; } }


    //for testing new movement
    private Vector3 startPosition;
    private Vector3 endPosition;
    private double dspSpawnTime;
    private double dspHitTime;

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
        /*
        if (audioTime == null) return;

        double audioDeltaTime = audioTime.DeltaTime;

        transform.position += (Vector3)(movementSpeed * (float) audioDeltaTime * direction);*/

        double t = AudioSettings.dspTime - dspSpawnTime;   // seconds since spawn (audio-accurate)
        if (t < 0) return; // if you scheduled spawn in the future

        if (t >= dspHitTime && transform.position.y < endPosition.y)
        {
            transform.position = endPosition;
        }

        // deterministic position (no per-frame accumulation)
        transform.position = startPosition + direction * (movementSpeed * (float)t);
    }

    public void Init(BeatParam b)
    {
        movementSpeed = b.GetBeatSpeed();
        startPosition = b.StartPos;
        endPosition = b.EndPos;
        dspSpawnTime = b.DspSpawnTime;
        dspHitTime = b.HitDspTime;
       // transform.position = b.StartPos;
        shoot = true;
    }


    /*
     * double t = AudioSettings.dspTime - spawnDspTime;   // seconds since spawn (audio-accurate)
        if (t < 0) return; // if you scheduled spawn in the future

        // deterministic position (no per-frame accumulation)
        transform.position = startPos + dirNorm * (speed * (float)t);

    //need spawndsptime
     */
}

[System.Serializable]
public struct BeatParam {
    public Vector3 StartPos;
    public Vector3 EndPos;
   public double TimeToLand;
    public double DspSpawnTime;
    public double HitDspTime;
    //spawndsptime would be
    //well. dsptime upon call.
    //arival time is dsptime + timetoland

    public BeatParam(Vector3 s, Vector3 e, double t)
    {
        StartPos = s;
        EndPos = e;
        TimeToLand = t;
        DspSpawnTime = AudioSettings.dspTime;
        HitDspTime = DspSpawnTime + t;
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