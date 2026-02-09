using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private bool shootTriggered = false;

    [SerializeField] private Vector2 projSize = new(1f, 1f);
    public Vector2 ProjSize { get { return projSize; } }



    private double spawnDspTime;
    private double hitDspTime;
    private Vector3 startPos;
    private Vector3 endPos;

    //startPos will be the notespawner pos,
    //endpos will be the targetspawner pos
    //spawnTime is TimeToGetToPad? current time. 
    //htiDspTIme is idfk. like the target time
    //transfomr positoin = 
    public void SpawnNote(Vector3 start, Vector3 end, double spawnTime, double hitTime)
    {
        Debug.Log("hi");
        //^ dis bein called
        startPos = start;
        endPos = end;
        spawnDspTime = spawnTime;
        hitDspTime = hitTime;

        transform.position = startPos; // set immediately
        shootTriggered = true;
    }
    //i need to move all of it to one freaking place bruh

    public void HandleMovement()
    {
        //v error w this?
        double now = AudioSettings.dspTime;
        double t = (now - spawnDspTime) / (hitDspTime - spawnDspTime);
        t = Mathf.Clamp01((float)t);

        transform.position = Vector3.Lerp(startPos, endPos, (float) t);
    }
    // private float speed;
    //  private Vector2 direction;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    private void Start()
    {
        //direction = Vector2.up;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (shootTriggered)
        {
            HandleMovement();
        }
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
