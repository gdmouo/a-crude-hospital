using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Farttface : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private float textSpeed;
    [SerializeField] private NameRunner nameRunner;
    private List<string> lines;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PackLines(List<string> s, string n)
    {
        lines = s;
        nameRunner.PackLine(n);
        StartDialogue();
        ToggleMouseInput(true);
    }

    public void ClickDialogueRunner()
    {
        if (textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < lines.Count - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {

            ToggleMouseInput(false);
        }
    }

    private void ToggleMouseInput(bool a)
    {
        if (a)
        {
            GameInput.Instance.ToggleIsSpeaking(a, this);
        } else
        {
            GameInput.Instance.ToggleIsSpeaking(a, null);
            //v
            textComponent.text = string.Empty;
            nameRunner.ClearLine();
        }
    }
}
