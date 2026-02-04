using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private TMP_Text bodyText;
    public bool IsOpen => panel != null && panel.activeSelf;

    private void Awake()
    {
        OnAwake();
    }

    public void SetOpen(bool open)
    {
        if (panel != null) panel.SetActive(open);
    }

    public void SetText(string speaker, string body)
    {
        if (speakerText != null) speakerText.text = speaker;
        if (bodyText != null) bodyText.text = body;
    }

    public void SetBodyOnly(string body)
    {
        if (bodyText != null) bodyText.text = body;
    }

    protected virtual void OnAwake()
    {
        SetOpen(false);
        SetText("", "");
    }

}
