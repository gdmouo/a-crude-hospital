using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public bool Emphasized { get; private set; }
    public Interactible Item { get { return item; } }

    [SerializeField] private Image backdrop;
    [SerializeField] private Interactible item;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private Image iconFaded;
    private const float EMPHASIZED_COLOR = (197f / 255f);
    private const float LIGHTENED_COLOR = (84f / 255f);
    private int slot;

    //For picking up
   // private bool mouseSelectingItem = false;

    private void Awake()
    {
        Emphasized = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        /*
        if (item != null)
        {
            Store(item);
        }*/
        Lighten();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (mouseSelectingItem)
        {
            if (!GameInput.Instance.IsMouseHolding())
            {
                MouseDrop();
            }
        }*/
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
            icon.sprite = i.GetIcon();
            Color color = new(1f, 1f, 1f, 1f);
            icon.color = color;
            icon.SetNativeSize();

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

    public void ChangeIconToHeldSprite()
    {
        icon.sprite = item.GetHeldIcon();
        icon.SetNativeSize();
    }

    public void ChangeIconToOpenedSprite()
    {
        icon.sprite = item.GetOpenedIcon();
        icon.SetNativeSize();
    }
    public void PutIconBack()
    {
        icon.sprite = item.GetIcon();
        icon.SetNativeSize();
        icon.GetComponent<RectTransform>().anchoredPosition = iconFaded.GetComponent<RectTransform>().anchoredPosition;
    }
}
