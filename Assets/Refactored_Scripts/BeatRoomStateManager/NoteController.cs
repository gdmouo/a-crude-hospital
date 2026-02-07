using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
 //   public static NoteController Instance { get; private set; }


    [SerializeField] private List<NoteSpawner> noteSpawners;
    //
    private Dictionary<KeyControlling, NoteSpawner> noteSpawnerDict;
    public Dictionary<KeyControlling, NoteSpawner> NSDict { get { return noteSpawnerDict; } }

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
