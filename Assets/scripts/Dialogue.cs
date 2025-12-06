using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    //public TextMeshProUGUI nameComponent;
    public string[] lines;
    public float textSpeed;
   // public string speakerName;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
       // nameComponent.text = speakerName;
        StartDialogue();

        //Debug.Log(" rect transform position: " + gameObject.GetComponent<RectTransform>().anchoredPosition);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
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
        }*/
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
           
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    public float GetFillAmount()
    {
        TextPos tp = new TextPos();
        float poo = (tp.GetLatestCharacterPos(textComponent) + 450f) / 900f;
        return poo;
    }
}


public class TextPos
{
    public float GetLatestCharacterPos(TMP_Text text)
    {
        text.ForceMeshUpdate();

        string s = text.text;

        // Example: get position of character 5
        int poop = s.Length;
        int charIndex = poop - 1;

        if (charIndex < 0 || charIndex >= s.Length) return 0f;

        TMP_TextInfo info = text.textInfo;
        TMP_CharacterInfo charInfo = info.characterInfo[charIndex];

        // The character is a quad, so get its midpoint
        Vector3 bottomLeft = charInfo.bottomLeft;
        Vector3 topRight = charInfo.topRight;
        Vector3 worldPos = (bottomLeft + topRight) * 0.5f;

        // Convert local to world if needed
       // worldPos = text.transform.TransformPoint(worldPos);
        Debug.Log("Character '" + s[charIndex] + "' world position: " + worldPos);

        return worldPos.x;

    }
}


