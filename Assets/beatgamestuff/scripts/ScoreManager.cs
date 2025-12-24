using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {  get; private set; }
    private float maxScore;
    private float currentScore;
    private float passingScore;

    public bool scoreInitialized { get; private set; }
    public bool songStarted { get; private set; }




    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        scoreInitialized = false;
        songStarted = false;
    }

    public void SetupScoreManager(float m, float s)
    {
        maxScore = m;
        currentScore = 0f;
        scoreInitialized = true;
        passingScore = s;
        songStarted = true;
    }

    public void UpdateScore(float f)
    {
        currentScore += f;
    }

    public float GetCurrentScore()
    {
        return (currentScore / maxScore) * 100f;
    }

    public bool Passed()
    {
        return GetCurrentScore() >= passingScore;
    }



}
