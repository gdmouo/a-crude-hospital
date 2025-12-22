using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITimeElapsed : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeElapsed;

    // Update is called once per frame
    void Update()
    {
        if (TimeManager.Instance.timeInitialized)
        {
            if (timeElapsed.text != "duration: " + TimeManager.Instance.GetCurrentTime().ToString() + " / " + TimeManager.Instance.GetMaxTime())
            {
                timeElapsed.text = "duration: " + TimeManager.Instance.GetCurrentTime().ToString() + " / " + TimeManager.Instance.GetMaxTime();
            }
        }
        else
        {
            if (timeElapsed.text != "Song not started")
            {
                timeElapsed.text = "Song not started";
            }
        }
    }
}
