using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldNoteController : MonoBehaviour
{
    [SerializeField] private List<OldNoteSpawner> noteSpawners;

    private Dictionary<PadLabel, OldNoteSpawner> noteSpawnerDict;
    public Dictionary<PadLabel, OldNoteSpawner> NSDict { get { return noteSpawnerDict; } }

    [Header("NoteSpawner Settings")]
    [SerializeField] private BeatPadController beatPadController;
  //  [SerializeField] private NoteSpawnerSettings noteSpawnerSettings;

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
    private Dictionary<PadLabel, OldNoteSpawner> GetNSDictionary(List<OldNoteSpawner> l)
    {
        if (l == null)
        {
            return null;
        }
        Dictionary<PadLabel, OldNoteSpawner> temp = new Dictionary<PadLabel, OldNoteSpawner>();
        foreach (OldNoteSpawner n in l)
        {
            temp.Add(n.GetKeyTarget(), n);
        }
        return temp;
    }
}