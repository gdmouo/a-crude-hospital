using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioTimeCanvas : MonoBehaviour
{
    [SerializeField] private AudioTime audioTime;
    [SerializeField] private TextMeshProUGUI textComponent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (audioTime != null)
        {
            textComponent.text = "audioTime: " + audioTime.GetAudioClock().ToString();
        }
    }
}
