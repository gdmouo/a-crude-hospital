using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    [SerializeField] private List<NoteSpawner> noteSpawners;

    private Dictionary<KeyControlling, NoteSpawner> noteSpawnerDict;
    public Dictionary<KeyControlling, NoteSpawner> NSDict { get { return noteSpawnerDict; } }

    [Header("NoteSpawner Settings")]
    [SerializeField] private BeatPadController beatPadController;
    [SerializeField] private NoteSpawnerSettings noteSpawnerSettings;

    private void Awake()
    {
       // Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (noteSpawners == null)
        {
            Debug.Log("Critical variable unassigned in: " + gameObject.name);
            return;
        }
        noteSpawnerDict = GetNSDictionary(noteSpawners);
    }

    public NoteSpawnerSettings GetAdjustedNoteSpawnerSettings()
    {
        if (beatPadController != null)
        {
            noteSpawnerSettings.SetDisplacement(beatPadController.GetPadYCoord(), GetNSYCoord());
        }

        return noteSpawnerSettings;
    }

    private float GetNSYCoord()
    {
        if (noteSpawners == null || noteSpawners.Count == 0)
        {
            return 0f;
        }
        return noteSpawners[0].transform.position.y;
    }

    private Dictionary<KeyControlling, NoteSpawner> GetNSDictionary(List<NoteSpawner> l)
    {
        if (l == null)
        {
            return null;
        }
        Dictionary<KeyControlling, NoteSpawner> temp = new Dictionary<KeyControlling, NoteSpawner>();
        foreach (NoteSpawner n in l)
        {
            temp.Add(n.KeyTarget, n);
        }
        return temp;
    }
}

[System.Serializable]
public struct NoteSpawnerSettings
{
    public Vector2 Direction;
    public GameObject NotePrefab;
    public Transform NoteSpace;
    public float Lifetime;
    private float displacement;

    public float RealDisplacement { get { return displacement; } }

    public void SetDisplacement(float a, float b)
    {
        displacement = Mathf.Abs(a - b);
    }
}

