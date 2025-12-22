using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueControl : MonoBehaviour
{
    public static DialogueControl Instance;
    [SerializeField] private TextMeshProUGUI textComponent;

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

    public void EnterText(string text)
    {
        SomeoneIsSpeaking = true;
        textComponent.text = text;
        textComponent.gameObject.SetActive(true);
    }

    public void EndText()
    {
       // if (test == 0)
       // {
       //     test = 1;
       //     return;
       // }
        SomeoneIsSpeaking = false;
        textComponent.gameObject.SetActive(false);
    }
}
