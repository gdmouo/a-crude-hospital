using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvSlot : MonoBehaviour
{
    public bool Emphasized { get; private set; }
    public Interactible Item { get { return item; } }

    [SerializeField] private Image backdrop;
    [SerializeField] private IntInvGUI intInvGUI;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private Image iconFaded;

    private const float EMPHASIZED_COLOR = (197f / 255f);
    private const float LIGHTENED_COLOR = (84f / 255f);

    private Interactible item;

    private int slot;

    private void Awake()
    {
        Emphasized = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        Lighten();
    }

    public void Emphasize()
    {
        Color changeTo = backdrop.color;
        changeTo.a = EMPHASIZED_COLOR;
        backdrop.color = changeTo;
        Emphasized = true;
    }

    public void Lighten()
    {
        Color changeTo = backdrop.color;
        changeTo.a = LIGHTENED_COLOR;
        backdrop.color = changeTo;
        Emphasized = false;
    }

    public void Store(Interactible i)
    {
        if (i.GetIcon() != null)
        {
            intInvGUI.SetParameters(i, this);

            iconFaded.sprite = i.GetIcon();
            Color color2 = new(1f, 1f, 1f, 0.05f);
            iconFaded.color = color2;
            iconFaded.SetNativeSize();
        }
        item = i;
        i.gameObject.SetActive(false);
        Player.Instance.SetInteractibleHoldingToNUll();
    }

    public void SetDigit(int digit)
    {
        slot = (digit + 1);
        textComponent.text = slot.ToString();
    }

    public Vector2 GetIconFadedPosition()
    {
        return iconFaded.GetComponent<RectTransform>().anchoredPosition;
    }
}
