using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bs_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
            //

            Beats beats = beatMapping[nextIndex];
            double spawnTime = Mathf.Max(beats.GetFloatArrivalTime() - flyTime, 0);

            if (trackTime >= spawnTime)
            {
                List<Beat> toMap = beats.BeatsToMap;

                if (toMap == null || toMap.Count == 0)
                {
                    return;
                }

                foreach (Beat b in toMap)
                {
                    Debug.Log("fart");
                    SpawnNote(b, flyTime);
                }

                nextIndex++;
            }*/

    /*
    private void HandleTrack()
    {
        double trackTime = AudioSettings.dspTime - trackStartTime;
       // Debug.Log("trackTime: " + trackTime.ToString());



        if (trackTime < 0)
        {
            return;
        }
        else if (trackTime >= trackEndTime)
        {
            EndTrack();
            return;
        }

        if (nextIndex < beatMapping.Count)
        {
            Beats beats = beatMapping[nextIndex];
            double spawnTime = Mathf.Max(beats.GetFloatArrivalTime() - flyTime, 0);

  
            if (trackTime >= spawnTime)
            {
                List<Beat> toMap = beats.BeatsToMap;

                if (toMap == null || toMap.Count == 0) {
                    return;
                }

                foreach (Beat b in toMap)
                {
                    Debug.Log("fart");
                    SpawnNote(b, flyTime);
                }

                nextIndex++;
            }
        }

    }*/

    /*
    private void SpawnNote(Beat beat, float f)
    {
        if (noteController == null)
        {
            return;
        }

        if (noteController.NSDict.TryGetValue(beat.Target, out NoteSpawner nSp))
        {
            nSp.FireNote(f, beat.LongBeatDuration, noteController.GetAdjustedNoteSpawnerSettings());
        }
    }*/

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

    /*
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
    }*/

    /*
     *  if (float.IsNaN(speed) || float.IsInfinity(speed))
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
