using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosedCaptionBar : MonoBehaviour
{
    
    public Dialogue d;
    [Header("UI")]
    public Image fillImage;          // Assign BarFill here in the Inspector

    [Header("Values")]
    public float maxValue = 100f;
    public float currentValue = 0f;
    public float growSpeed = 20f;    // units per second

    float fadeValue = 0f;
    float fadeSpeed = 5f;

    void FixedUpdate()
    {
        // Example: automatically grow over time
        if ((currentValue / maxValue) < d.GetFillAmount() + 0.05f)
        {
            currentValue += growSpeed * Time.deltaTime;
            currentValue = Mathf.Clamp(currentValue, 0f, maxValue);
        }

        UpdateBar();
        FadeIn();
    }

    public void SetValue(float value)
    {
        currentValue = Mathf.Clamp(value, 0f, maxValue);
        UpdateBar();
    }

    public void AddValue(float amount)
    {
        SetValue(currentValue + amount);
    }

    void UpdateBar()
    {
        if (fillImage == null) return;
        float normalized = maxValue <= 0 ? 0 : currentValue / maxValue;
        fillImage.fillAmount = normalized;
        // fillImage.fillAmount = d.GetFillAmount();
        //
        //normalized; // 0 = empty, 1 = full
    }

    private void SetImageAlpha(float amount, Image image)
    {
        Color c = image.color;
        c.a = amount;
        image.color = c;
    }

    private void FadeIn()
    {
        if (fadeValue < 1f)
        {
            fadeValue = Mathf.Clamp(fadeValue + (0.1f * Time.deltaTime * fadeSpeed), 0f, 1f);
        }
        SetImageAlpha(fadeValue, fillImage);
    }

}
