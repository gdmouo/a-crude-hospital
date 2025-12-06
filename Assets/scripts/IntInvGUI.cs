using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class IntInvGUI : MonoBehaviour
{
    private InvSlot inventorySlot;
    private Image icon;
    private InteractibleSO itemSO;

    private RectTransform rectTransform;
    private Canvas canvas;

    private bool caseOpened = false;

    //

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        icon = GetComponent<Image>();
    }

    private void Start()
    {
    }


    void Update()
    {
    }

    public void OnBeginDrag(BaseEventData data)
    {
        ChangeIconToHeldSprite();

        //change to this
        Debug.Log("Item draggd");
    }

    public void OnDrag(BaseEventData data)
    {
        var pointerData = (PointerEventData)data;
        rectTransform.anchoredPosition += pointerData.delta / canvas.scaleFactor;

        CheckForPillcase();
    }

    public void OnEndDrag(BaseEventData data)
    {
        PutIconBack();

        //reset
        Debug.Log("Item droppd");
    }

    public void SetIcon()
    {
        icon.sprite = itemSO.sprite;
        Color color = new(1f, 1f, 1f, 1f);
        icon.color = color;
        icon.SetNativeSize();
    }

    public void ChangeIconToHeldSprite()
    {
        icon.sprite = itemSO.heldSprite;
        icon.SetNativeSize();
    }

    public void ChangeIconToOpenedSprite()
    {
        icon.sprite = itemSO.openedSprite;
        icon.SetNativeSize();
    }
    public void PutIconBack()
    {
        icon.sprite = itemSO.sprite;
        icon.SetNativeSize();
        icon.GetComponent<RectTransform>().anchoredPosition = inventorySlot.GetIconFadedPosition();
    }

    public void SetParameters(InteractibleSO interactibleSO, InvSlot iS)
    {
        itemSO = interactibleSO;
        inventorySlot = iS;
        SetIcon();
    }

    public void FallPill()
    {
        if (caseOpened)
        {
            //drop
            
        }
    }


    private void CheckForPillcase()
    {
        RectTransform targetAreaRectTransform = PillcaseUI.Instance.GetCRT();

        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            targetAreaRectTransform,
            rectTransform.position, // Use world position for conversion
            canvas.worldCamera,
            out localPoint))
        {
            // Check if the local point is within the target area's local bounds
            if (targetAreaRectTransform.rect.Contains(localPoint))
            {
               // Debug.Log("UI object dropped within the target area!");
                // Perform actions for dropping within the area
                //inventorySlot.ChangeIconToOpenedSprite();
                ChangeIconToOpenedSprite();
                caseOpened = true;
                //inventorySlot.TogglePoop(true);
            }
            else
            {
               // Debug.Log("UI object dropped outside the target area.");
                // Perform actions for dropping outside the area
                ChangeIconToHeldSprite();
                caseOpened = false;
                // inventorySlot.TogglePoop(false);
            }
        }
    }
}
