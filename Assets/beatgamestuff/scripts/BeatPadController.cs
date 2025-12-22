using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeatPadController : MonoBehaviour
{
    public static BeatPadController Instance { get; private set; }
    [SerializeField] private Transform BeatParent;
    private Dictionary<Dir, BeatPad> keyBeatPads;

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
        BeatPad hit = null;

        if (keyBeatPads.TryGetValue(fart, out BeatPad bP))
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
        keyBeatPads = new Dictionary<Dir, BeatPad>();
        foreach (Transform child in BeatParent.transform)
        {
            BeatPad beatPad = child.gameObject.GetComponent<BeatPad>();
            keyBeatPads.Add(beatPad.KeyButton, beatPad);
        }
    }

}

