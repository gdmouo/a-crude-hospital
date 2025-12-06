using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ISIUIDrag : MonoBehaviour
{
    [SerializeField] private InventorySlot inventorySlot;

    private RectTransform rectTransform;
    private Canvas canvas;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(BaseEventData data)
    {
        // Optional stuff here
        inventorySlot.ChangeIconToHeldSprite();
    }

    public void OnDrag(BaseEventData data)
    {
        var pointerData = (PointerEventData)data;
        rectTransform.anchoredPosition += pointerData.delta / canvas.scaleFactor;


        HandlePillcase();
    }

    public void OnEndDrag(BaseEventData data)
    {
        inventorySlot.PutIconBack();
        // Optional stuff here
    }

    private void HandlePillcase()
    {
        RectTransform targetAreaRectTransform = PillcaseUI.Instance.GetCRT();

        //////
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
                Debug.Log("UI object dropped within the target area!");
                // Perform actions for dropping within the area
                inventorySlot.ChangeIconToOpenedSprite();
               // inventorySlot.TogglePoop(true);

                //rectTransform.anchoredPosition
            }
            else
            {
                Debug.Log("UI object dropped outside the target area.");
                // Perform actions for dropping outside the area
                inventorySlot.ChangeIconToHeldSprite();
               // inventorySlot.TogglePoop(false);
            }
        }
    }
}
