using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pussyvagin : MonoBehaviour
{
    public static Pussyvagin Instance { get; private set; }
    [SerializeField] private Transform BeatParent;
    private Dictionary<Dir, Condom> keyBeatPads;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Menu instance found");
        }
        Instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        Poo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HitBar(Dir fart)
    {
        Condom hit = null;

        if (keyBeatPads.TryGetValue(fart, out Condom bP))
        {
            hit = bP;
        }

        if (hit != null)
        {
            hit.Interact();
        }

    }

    public void Poo()
    {
        keyBeatPads = new Dictionary<Dir, Condom>();
        foreach (Transform child in BeatParent.transform)
        {
            Condom beatPad = child.gameObject.GetComponent<Condom>();
            keyBeatPads.Add(beatPad.KeyButton, beatPad);
        }
    }

}

