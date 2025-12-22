using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScoreUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreCounter;

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.Instance.scoreInitialized)
        {
            if (scoreCounter.text != "score: " + ScoreManager.Instance.GetCurrentScore().ToString())
            {
                scoreCounter.text = "score: " + ScoreManager.Instance.GetCurrentScore().ToString();
            }
        } else
        {
            if (scoreCounter.text != string.Empty)
            {
                scoreCounter.text = string.Empty;
            }
        }
    }
}
