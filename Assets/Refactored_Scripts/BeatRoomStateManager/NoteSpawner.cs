using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private Vector2 direction;

    [SerializeField] private KeyControlling keyTargeting;
    public KeyControlling KeyTarget { get { return keyTargeting; } }

    // Start is called before the first frame update
    private void Start()
    {
        //somethign else should set pos
        //transform.position = new(targetPad.transform.position.x, transform.position.y, 0f);
    }

    public void FireNote(float timeToGetToPad)
    {
        GameObject temp = Instantiate(notePrefab, transform.position, Quaternion.identity);
        temp.transform.SetParent(NoteSpace.Instance.transform);
        temp.GetComponent<Note>().SpawnNote(direction, timeToGetToPad);
    }

    public void SetPos(Vector2 pos)
    {
        transform.position = new(pos.x, pos.y, 0f);
    }
}
