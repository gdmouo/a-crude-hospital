using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class IntInvGUI : MonoBehaviour, IInvSlotGUI
{
    protected InvSlot inventorySlot;
    protected Image icon;
    protected ItemSO itemSO;
    protected RectTransform rectTransform;
    protected Canvas canvas;
    protected Item item;

    protected bool startTimer = false;
    protected const float TIMER_MAX = 0.5f;
    protected float timer = 0f;

    //
    protected GameObject descriptionGUI;
    protected ItemDescGUI intDescGUI;

    //

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        icon = GetComponent<Image>();
        //intDescGUI = descriptionGUI.GetComponent<ItemDescGUI>();
    }

    protected void SetStuffUp()
    {
        if (rectTransform == null)
        {
            rectTransform = gameObject.GetComponent<RectTransform>();
        }
        if (canvas == null)
        {
            canvas = gameObject.GetComponentInParent<Canvas>();
        }
        if (icon == null)
        {
            icon = gameObject.GetComponent<Image>();
        }
    }

    private void Start()
    {

    }


    void Update()
    {
        if (startTimer)
        {
            if (timer < TIMER_MAX)
            {
                timer += Time.deltaTime;
                Debug.Log(timer);
            }
            else
            {
               // EndTimer();
                ShowDescGUI();
                //show gui
                //show description gui
            }
        }
    }

    public virtual void OnBeginDrag(BaseEventData data)
    {
        ChangeIconToHeldSprite();

        //change to this
        // Debug.Log("Item draggd");
        GameInput.Instance.SetSelectedIIGUI(this);
    }

    public virtual void OnDrag(BaseEventData data)
    {
        var pointerData = (PointerEventData)data;
        rectTransform.anchoredPosition += pointerData.delta / canvas.scaleFactor;

        //CheckForPillcase();
    }

    public virtual void OnEndDrag(BaseEventData data)
    {
        PutIconBack();
        GameInput.Instance.SetSelectedIIGUI(null);
    }

    public virtual void OnPointerEnter(BaseEventData data)
    {
        if (startTimer)
        {
            return;
        }
        EndTimer();
        ResetTimer();
        StartTimer();
    }

    public virtual void OnPointerExit(BaseEventData data)
    {
        EndTimer();
        ResetTimer();
        HideDescGUI();
        //hide gui if displayed
    }

    public virtual void GUIHoldingInteract()
    {

    }

    protected void StartTimer() {
        startTimer = true;
    }

    protected void EndTimer()
    {
        startTimer = false;
    }
    protected void ResetTimer()
    {
        timer = 0f;
    }

    protected void ShowDescGUI()
    {
        if (!descriptionGUI.activeSelf)
        {
            if (!intDescGUI.TextSet)
            {
                intDescGUI.SetParameters(item, inventorySlot);

            }
            descriptionGUI.SetActive(true);
        }
    }

    protected void HideDescGUI()
    {
        if (descriptionGUI.activeSelf)
        {
            descriptionGUI.SetActive(false);
        }
    }

    public void SetIcon()
    {
        icon.sprite = itemSO.sprite;
        Color color = new(1f, 1f, 1f, 1f);
        icon.color = color;
        icon.SetNativeSize();

        //
        icon.GetComponent<RectTransform>().anchoredPosition = inventorySlot.GetIconFadedPosition();
    }

    protected void ChangeIconToHeldSprite()
    {
        icon.sprite = itemSO.heldSprite;
        icon.SetNativeSize();
    }

    protected void PutIconBack()
    {
        icon.sprite = itemSO.sprite;
        icon.SetNativeSize();
        icon.GetComponent<RectTransform>().anchoredPosition = inventorySlot.GetIconFadedPosition();
    }

    public void SetParameters(Interactible interactible, InvSlot iS, ItemDescGUI iD)
    {
        item = interactible as Item;
        item.SetGUIIntParam(this);
        itemSO = item.GetInteractibleSO() as ItemSO;
        inventorySlot = iS;
        descriptionGUI = iD.gameObject;
        intDescGUI = iD;
        SetIcon();
        HideDescGUI();
        ///////
    }

    public ItemDescGUI GetItemDescGUI()
    {
        return intDescGUI;
    }
}
