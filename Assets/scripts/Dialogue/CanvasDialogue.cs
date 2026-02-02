using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasDialogue : MonoBehaviour
{
    [SerializeField] private SpeakerScripts speakerScripts;
    [SerializeField] private Farttface dialogueRunner;

    public static CanvasDialogue Instance {  get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //

    public void InitDialogue(Speaker speaker)
    {
        //ref to database
        //get strings of dialogue 
        Debug.Log("spoke with" + speaker.SpeakerName.ToString());

        List<string> d = speakerScripts.GetScript(speaker.SpeakerName);

        dialogueRunner.PackLines(d, speaker.SpeakerName.ToString());
        
    }
}

//struct for dialogue
//presumably text, list of responses
//
//
////, update database based on response
///

//database