using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    // private BeatPad targetPad;
    private bool shoot = false;
    // [SerializeField] private float travelDuration = 2f;
    [SerializeField] private Vector2 projSize = new(1f, 1f);

    private Dir dir;

    public Vector2 ProjSize { get { return projSize; } }

    private float speed = 12f;
    private float lifetime = 10f;

    private Vector2 direction;

    [SerializeField] private float displacement;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        //
        // Destroy(gameObject, lifetime
        switch (dir)
        {
            case Dir.durn:
                direction = Vector2.down;
                break;
            case Dir.rut:
                direction = Vector2.right;
                break;
            case Dir.urp:
                direction = Vector2.up;
                break;
            case Dir.lurft:
                direction = Vector2.left;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot)
        {

            Shoot();
        }
    }

    public void Touch()
    {

    }

    public void Shoot()
    {
        if (float.IsNaN(speed) || float.IsInfinity(speed))
        {
            return;
        }
        transform.position += (Vector3)(speed * Time.deltaTime * direction);
        /*
        if (target != null) {
            endPos = target.transform.position;
        }
        else
        {
            endPos = startPos;
        }
        transform.position = Vector3.Lerp(transform.position, endPos, travelDuration);
        */
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, projSize);
    }

    public void Fire(Dir d/*, BeatPad b*/)
    {
        dir = d;
        // targetPad = b;
        shoot = true;
    }

    public void ShootGunn(Dir d, float time)
    {
        dir = d;
        speed = displacement / time;
        shoot = true;
        Destroy(gameObject, lifetime);
    }
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // other.GetComponent<EnemyHealth>()?.TakeDamage(1);
            Destroy(gameObject);
        }
    }*/


}

/*
using UnityEngine;

public class Note : MonoBehaviour
{
    float hitTime;              // in song-seconds (not real time)
    float travelSeconds;
    Vector3 spawnPos, hitPos;

    double dspSongStartTime;
    float songOffset;

    bool hit;

    public void Init(
        float noteHitTime,
        float secondsPerBeat,
        Vector3 spawnPosition,
        Vector3 hitPosition,
        float noteTravelSeconds,
        double dspStart,
        float offsetSeconds
    )
    {
        hitTime = noteHitTime;
        spawnPos = spawnPosition;
        hitPos = hitPosition;
        travelSeconds = noteTravelSeconds;
        dspSongStartTime = dspStart;
        songOffset = offsetSeconds;
    }

    void Update()
    {
        if (hit) return;

        float songTime = (float)(AudioSettings.dspTime - dspSongStartTime) - songOffset;

        // We want: at (hitTime - travelSeconds) -> spawnPos, and at hitTime -> hitPos
        float t = Mathf.InverseLerp(hitTime - travelSeconds, hitTime, songTime);
        transform.position = Vector3.Lerp(spawnPos, hitPos, t);

        // Miss cleanup: if it passed the hit time by a lot
        if (songTime > hitTime + 0.25f)
        {
            Destroy(gameObject);
        }
    }

    // Called by a "HitDetector" when player presses
    public float GetTimeError(float songTime) => songTime - hitTime;

    public void MarkHit()
    {
        hit = true;
        Destroy(gameObject);
    }
}
*/