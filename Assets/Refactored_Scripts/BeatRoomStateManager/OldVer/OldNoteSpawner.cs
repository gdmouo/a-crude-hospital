using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldNoteSpawner : MonoBehaviour
{
    [SerializeField] private OldNoteSpawnerSettings noteSpawnerSettings;

    private bool initialized = false;
    public bool Initialized { get { return initialized; } }

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new(noteSpawnerSettings.TargetPad.transform.position.x, transform.position.y, 0f);
    }

    public KeyControlling GetKeyTarget()
    {
        return noteSpawnerSettings.TargetPad.KeyButton;
    }

    public OldNoteSpawnerSettings GetNoteSpawnerSettings()
    {
        return noteSpawnerSettings;
    }


    public GameObject SpawnGetNote()
    {
        if (!initialized)
        {
            InitSpawnerSettings();
        }

        GameObject temp = Instantiate(noteSpawnerSettings.NotePrefab, transform.position, Quaternion.identity);
        temp.transform.SetParent(noteSpawnerSettings.NoteSpace);

        return temp;
    }

    private void InitSpawnerSettings()
    {
        noteSpawnerSettings.SetNoteSpace(NoteSpace.Instance.transform);
        initialized = true;
    }
}


[System.Serializable]
public struct OldNoteSpawnerSettings
{
    public Vector2 Direction;
    public GameObject NotePrefab;
    public BeatPad TargetPad;
   // public float FlyTime;

    public Transform NoteSpace { get { return noteSpace; } }

    private Transform noteSpace;

    public void SetNoteSpace(Transform t)
    {
        noteSpace = t;
    }

    /*
    private float displacement;

    public float RealDisplacement { get { return displacement; } }

    public void SetDisplacement(float a, float b)
    {
        displacement = Mathf.Abs(a - b);
    }*/
}


