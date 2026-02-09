using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    //[SerializeField] private KeyControlling keyTargeting;
    [SerializeField] private BeatPad targetPad;
    public KeyControlling KeyTarget { get { return targetPad.KeyButton; } }

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new(targetPad.transform.position.x, transform.position.y, 0f);
        //somethign else should set pos
        //transform.position = new(targetPad.transform.position.x, transform.position.y, 0f);
    }


    /*
    public void FireNote(float timeToGetToPad, double longBeatDuration, NoteSpawnerSettings n)
    {
        
        if (longBeatDuration < 1f)
        {
           // Debug.Log("NOO");
            GameObject temp = Instantiate(n.NotePrefab, transform.position, Quaternion.identity);
            temp.transform.SetParent(n.NoteSpace);
            temp.GetComponent<Note>().SpawnNote(n.Direction, timeToGetToPad, n.RealDisplacement, n.Lifetime);
            //start, end. spawntime. hittime
        }
    }*/
    public void FireNote(double spawnTime, double hitTime, double longBeatDuration, NoteSpawnerSettings n)
    {

        if (longBeatDuration < 1f)
        {
            GameObject temp = Instantiate(n.NotePrefab, transform.position, Quaternion.identity);
            temp.transform.SetParent(n.NoteSpace);
            //temp.GetComponent<Note>().SpawnNote(n.Direction, timeToGetToPad, n.RealDisplacement, n.Lifetime);
            temp.GetComponent<Note>().SpawnNote(transform.position, targetPad.transform.position, spawnTime, hitTime);
            //start, end. spawntime. hittime
        }
    }
}
