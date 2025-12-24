using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultButtonVisuals : MonoBehaviour
{
    [SerializeField] private GameObject replayButton;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private TextMeshProUGUI digitScore;
    [SerializeField] private TextMeshProUGUI scorePhrase;

    public void ShowDaCorrectButton(bool passed, float s) {
        digitScore.text = s.ToString();
        if (passed)
        {
            if (!continueButton.activeSelf)
            {
                continueButton.SetActive(true);
            }

            if (replayButton.activeSelf)
            {
                replayButton.SetActive(false);
            }

            scorePhrase.text = "Noice";
        } else
        {
            if (!replayButton.activeSelf)
            {
                replayButton.SetActive(true);
            }

            if (continueButton.activeSelf)
            {
                continueButton.SetActive(false);
            }

            scorePhrase.text = "Sokay";
        }
    }
}
