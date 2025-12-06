using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClosedCaption : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    private string lineToPrint;
    private float textSpeed;
    private bool initialized = false;

    public void StartDialogue()
    {
        if (!initialized)
        {
            Debug.LogError("Must be initialized.");
        }
        //start the bar
        StartCoroutine(TypeLine());
    }
    public void Initialize(string line, float speed)
    {
        if (textComponent == null)
        {
            textComponent = gameObject.GetComponent<TextMeshProUGUI>();
        }
        textComponent.text = string.Empty;
        lineToPrint = line;
        textSpeed = speed;
        //create bar
        initialized = true;
    }
    private IEnumerator TypeLine()
    {
        foreach (char c in lineToPrint.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
