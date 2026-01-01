using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUIControl : MonoBehaviour
{
    public static DialogueUIControl Instance;
    [SerializeField] private TextMeshProUGUI textComponent;

    private List<string> lines;
    private int currIdx;

    public bool SomeoneIsSpeaking {  get; private set; }
    // Start is called before the first frame update

   // private int test = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        SomeoneIsSpeaking = false;
    }
    void Start()
    {
        textComponent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDialogueLoaded()
    {
        if (!textComponent.gameObject.activeSelf)
        {
            textComponent.gameObject.SetActive(true);
        }
        currIdx = 0;
        SomeoneIsSpeaking = true;
    }

    private void EnterText(string text)
    {
        textComponent.text = text;
    }

    public void LoadDialogue(List<Dialogue> l)
    {
        lines ??= new List<string>();
        foreach (Dialogue dialogue in l)
        {
            lines.Add(dialogue.Line);
        }
        OnDialogueLoaded();
    }

    public void ProgressDialogue()
    {
        if (currIdx >=  lines.Count)
        {
            EndText();
        }
        EnterText(lines[currIdx]);
    }

    
    private void EndText()
    {
        SomeoneIsSpeaking = false;
        textComponent.gameObject.SetActive(false);
    }
}
