using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShakeDetector : MonoBehaviour
{
    public float shakeThreshold = 2.0f; // Adjust this value
    public float shakeDuration = 3.0f;
    //public UnityEvent OnShakeTriggered; // Assign your event in the Inspector

    private float currentShakeTime = 0f;
    private bool isShaking = false;

    void Update()
    {
        // Get device acceleration
        Vector3 acceleration = Input.acceleration;
        Debug.Log(acceleration.magnitude);

        // Check if the device is being shaken
        if (acceleration.magnitude > shakeThreshold)
        {
            if (!isShaking)
            {
                isShaking = true;
                currentShakeTime = 0f; // Start or reset timer
            }
            currentShakeTime += Time.deltaTime;

            if (currentShakeTime >= shakeDuration)
            {
                Debug.Log("WJODJWODJK");
               // OnShakeTriggered.Invoke();
                currentShakeTime = 0f; // Reset for next shake
                isShaking = false; // Stop tracking shake until next event
            }
        }
        else
        {
            // If not shaking, reset the timer and state
            currentShakeTime = 0f;
            isShaking = false;
        }
    }
}
