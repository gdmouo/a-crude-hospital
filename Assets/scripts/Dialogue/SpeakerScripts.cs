using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<string> GetScript(SpeakerKeys speaker)
    {
        switch (speaker)
        {
            case SpeakerKeys.DogEevee:
                return new List<string>() { new("Broseph bon"), new("meep"), new("meo") };
            default:
                return new List<string>() { new("No dialogue available")};
        }
    }


}

[System.Serializable]
public enum SpeakerKeys
{
    DogEevee
}

//[System.Serializable]
// struct 
