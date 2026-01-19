using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HallwayGameCanvasManager : MonoBehaviour
{
    public static HallwayGameCanvasManager Instance;
    [SerializeField] private GameObject visualParent;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI stepLabelText;
    [SerializeField] private TextMeshProUGUI indexText;

    private void Awake()
    {
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

    public void Activate()
    {
        if (!visualParent.activeSelf)
        {
            ToggleVisibility(true);
        }
    }

    public void ToggleVisibility(bool a)
    {
        visualParent.SetActive(a);
    }

    public void SetStepText(string t)
    {
        if (stepLabelText.text != t)
        {
            stepLabelText.text = t;
        }
    }

    public void SetTimerText(string t)
    {
        if (timerText.text != t)
        {
            timerText.text = t;
        }
    }

    public void SetStepIndexText(string t)
    {
        if (indexText.text != t)
        {
            indexText.text = t;
        }
    }
}
