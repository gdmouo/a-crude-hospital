using UnityEngine;

public abstract class BeatProjectile : MonoBehaviour
{
    private Vector3 colliderSize;
    protected float movementSpeed;
    private Vector3 start;
    private Vector3 end;
    private double dspSpawnTime;
    private double dspHitTime;
    private bool firing = false;

    private bool hitTarget = false;


    private const float MAX_DIST = 20f;

    public Vector3 ColliderSize { get { return colliderSize; } }

    private void Awake()
    {
        colliderSize = transform.localScale;
    }
    private void Update()
    {
        UpdateFunction();
    }
    public virtual void Init(Note note, Vector3 spawnPos, Vector3 targetPos)
    {
        end = new Vector3(spawnPos.x, targetPos.y, spawnPos.z);
        start = spawnPos;
        movementSpeed = GetBeatSpeed(start, end, (float) note.GetBeatFlyTime());
        dspSpawnTime = AudioSettings.dspTime;
        dspHitTime = dspSpawnTime + note.GetBeatFlyTime();
       // vecDirection = GetVecDirection(spawnPos.y, targetPos.y);
    }

    public virtual void Shoot()
    {
        firing = true;
    }
    protected virtual void UpdateFunction()
    {
        /*
        if (!firing) return;

        Debug.Log("firing");

        double t = AudioSettings.dspTime - dspSpawnTime;   // seconds since spawn (audio-accurate)
        if (t < 0) return; // if you scheduled spawn in the future

        if (t >= dspHitTime && transform.position.y < end.y)
        {
            transform.position = end;
        }


        //   transform.position = start + vecDirection * (movementSpeed * (float)t);
        */

        if (!firing) return;

        double t = AudioSettings.dspTime - dspSpawnTime;
        if (t < 0) return;

        float distanceTravelled = movementSpeed * (float)t;

        float totalDistance = Vector3.Distance(start, end);

        //

        if ((distanceTravelled >= totalDistance || t >= dspHitTime) && !hitTarget)
        {
            hitTarget = true;
            Bar.Instance.Light();
        }

        /*
        if (distanceTravelled >= totalDistance || t >= dspHitTime)
        {
            transform.position = end;
            firing = false;
           // return;
        }
        */

        if (distanceTravelled >= MAX_DIST)
        {
            firing = false;
            return;
        }

        Vector3 direction = (end - start).normalized;

      //  Debug.Log(distanceTravelled);


        transform.position = start + direction * distanceTravelled;
    }
    private float GetBeatSpeed(Vector3 a, Vector3 b, float beatFlyTime)
    {
        float displacement = Vector3.Distance(a, b);
        return displacement / beatFlyTime;
    }


    /*
    private Vector3 GetVecDirection(float startY, float endY)
    {
        float diff = startY - endY;
        if (diff >= 0)
        {
            return Vector3.down;
        } else
        {
            return Vector3.up;
        }
    }*/
}
