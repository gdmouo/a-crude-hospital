using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour
{
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
    }

    public void OnDrag(BaseEventData data)
    {
        var pointerData = (PointerEventData)data;
        rectTransform.anchoredPosition += pointerData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(BaseEventData data)
    {
        // Optional stuff here
    }
}
