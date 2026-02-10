using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldNote : MonoBehaviour
{
    private bool shootTriggered = false;

    [SerializeField] private Vector2 projSize = new(1f, 1f);
    public Vector2 ProjSize { get { return projSize; } }

    private double spawnTime;
    private double arrivalTime;
    private double startTime;

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 direction;
    private float flyTime;

    private double lastDspTime;
    

    private void Awake()
    {
    }
    // Start is called before the first frame update
    private void Start()
    {
        //direction = Vector2.up;
    }

    // Update is called once per frame
    private void Update()
    {
        if (shootTriggered)
        {
            HandleMovement();
        }
    }

    public void Init(Vector3 spawnerPos, Vector3 targetPadPos, double s, double a, double t, float f, Vector3 d)
    {
       // Debug.Log(gameObject.name + " fired at: " + AudioSettings.dspTime.ToString());

        startPos = spawnerPos;
        endPos = targetPadPos;

        spawnTime = s;
        arrivalTime = a;
        startTime = s;
        flyTime = f;
        direction = d;
        lastDspTime = AudioSettings.dspTime;

        transform.position = startPos; // set immediately
        shootTriggered = true;
    }

    //i need to move all of it to one freaking place bruh

    public void HandleMovement()
    {
        /*
        double currAudioTime = AudioSettings.dspTime - startTime;
        double t = (currAudioTime - spawnTime) / (arrivalTime - spawnTime);
        t = Mathf.Clamp01((float)t);*/

        double currentDspTime = AudioSettings.dspTime;
        double dspDeltaTime = currentDspTime - lastDspTime;
        lastDspTime = currentDspTime;

        //dsptime - starttime = song curr time
        //arrival time = arrival time
        //




      //  Debug.Log("currAudioTime: " + currAudioTime.ToString() + " t: " + t);

        float speed = GetSpeed(startPos, endPos, flyTime);

        float time = (float)dspDeltaTime;
            //Time.deltaTime;
        

        transform.position += (Vector3)(speed * time * direction); 

        /*
        transform.position = Vector3.Lerp(startPos, endPos, (float)t);*/

        /*
        if (float.IsNaN(speed) || float.IsInfinity(speed))
        {
            return;
        }
        the problem was delta time... hrmmmmmmmm.
        transform.position += (Vector3)(speed * Time.deltaTime * direction);*/
    }

    private float GetSpeed(Vector3 a, Vector3 b, float f)
    {
        float displacement = Vector3.Distance(a, b);
        float speed = displacement / f;
        return speed;
    }


    //probabyl something here..................................................
    /*
    public void HandleMovement()
    {
        if (float.IsNaN(speed) || float.IsInfinity(speed))
        {
            return;
        }
        transform.position += (Vector3)(speed * Time.deltaTime * direction);

    }*/

    //probabyl something here..................................................
    /*
    public void SpawnNote(Vector2 dir, float timeToGetToPad, float displacement, float lifeTime)
    {
        direction = dir;
        speed = displacement / timeToGetToPad;
        shootTriggered = true;
        Destroy(gameObject, lifeTime);
    }*/

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, projSize);
    }
}
