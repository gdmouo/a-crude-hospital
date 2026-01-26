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
    private IntInvGUI intInvGUI;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private Image iconFaded;

    //fix later
    [SerializeField] GameObject iiguiPrefab;
    [SerializeField] GameObject pbguiPrefab;

    [SerializeField] GameObject iiDescGUI;
    [SerializeField] GameObject pbDescGUI;

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

    private GameObject GenerateIGUI(Interactible i)
    {
        GameObject toReturn;
        if (i.GetType() == typeof(PillBottle))
        {
            toReturn = Instantiate(pbguiPrefab);
        } else
        {
            toReturn = Instantiate(iiguiPrefab);
        }

        toReturn.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        toReturn.transform.SetParent(transform);

        return toReturn;
    }

    private GameObject GenerateItemDescGUI(Interactible i)
    {
        GameObject toReturn;
        if (i.GetType() == typeof(PillBottle))
        {
            toReturn = Instantiate(pbDescGUI);
        }
        else
        {
            toReturn = Instantiate(iiDescGUI);
        }

        toReturn.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        toReturn.transform.SetParent(transform);

        return toReturn;
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
        Sprite spr = (i as Pickup).GetIcon();
        if (spr != null)
        {
            //t
            

            GameObject temp = GenerateIGUI(i);
            intInvGUI = temp.GetComponent<IntInvGUI>();
            

            GameObject descGUI = GenerateItemDescGUI(i);

            intInvGUI.SetParameters(i, this, descGUI.GetComponent<ItemDescGUI>());

            //

            iconFaded.sprite = spr;
            Color color2 = new(1f, 1f, 1f, 0.05f);
            iconFaded.color = color2;
            iconFaded.SetNativeSize();
        }
        item = i;
        i.gameObject.SetActive(false);
        Player.Instance.SetInteractibleHoldingToNUll();


        //
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
