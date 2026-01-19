using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PBInvGUI : IntInvGUI
{
    private bool caseOpened = false;


    public override void OnDrag(BaseEventData data)
    {
        SetStuffUp();
        var pointerData = (PointerEventData)data;
        rectTransform.anchoredPosition += pointerData.delta / canvas.scaleFactor;

        CheckForPillcase();
    }

    
    public void ChangeIconToOpenedSprite()
    {
        icon.sprite = (itemSO as PillBottleSO).openedSprite;
        icon.SetNativeSize();
    }

    
    private void FallPill()
    {
        if (caseOpened)
        {
            //drop
            item.GUIInteract();
            Debug.Log("pill fell");

        }
    }

    public override void GUIHoldingInteract()
    {
        FallPill();
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
