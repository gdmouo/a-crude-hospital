using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillBottleGUI : InteractibleGUI
{
    [SerializeField] private float shakeThreshold = 1.0f;   // required speed to count as shaking
    [SerializeField] private float shakeDuration = 3.0f;    // seconds of continuous shaking

    //public System.Action OnShakeComplete; // event callback

    private float shakeTimer = 0f;
    private Vector2 lastPosition;

    private RectTransform rectTransform;

    private bool caseOpened = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        lastPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        if (caseOpened)
        {
            Vector2 velocity = (rectTransform.anchoredPosition - lastPosition) / Time.deltaTime;
            float speed = velocity.magnitude;

            // Check if object is shaking fast enough
            if (speed > shakeThreshold)
            {
                shakeTimer += Time.deltaTime;

                if (shakeTimer >= shakeDuration)
                {
                    shakeTimer = 0f;
                    Debug.Log("SHAKE EVENT TRIGGERED!");

                    //OnShakeComplete?.Invoke();
                }
            }
            else
            {
                shakeTimer = 0f; // reset if shaking stopped
            }
        }
        lastPosition = transform.position;
    }



    public override void Toggle(bool control)
    {
        ToggleBottle(control);
    }

    public void ToggleBottle(bool control)
    {
        caseOpened = control;
    }
}
