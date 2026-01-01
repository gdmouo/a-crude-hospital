using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameRunner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private float textSpeed;
    private string speakerName;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PackLine(string p)
    {
        speakerName = p;
        StartDialogue();
    }

    public void ClearLine()
    {
        textComponent.text = string.Empty;
    }

    private void StartDialogue()
    {
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in speakerName.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
