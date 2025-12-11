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
    private Interactible item;

    private bool caseOpened = false;

     [SerializeField] private Pill pill;


    private bool startTimer = false;
    [SerializeField] private float timerMax = 4f;
    private float timer = 0f;

    [SerializeField] private GameObject descriptionGUI;
    private IntDescGUI intDescGUI;

    //

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        icon = GetComponent<Image>();
        intDescGUI = descriptionGUI.GetComponent<IntDescGUI>();
    }

    private void Start()
    {

    }


    void Update()
    {
        if (startTimer)
        {
            if (timer < timerMax)
            {
                timer += Time.deltaTime;
            }
            else
            {
                EndTimer();
                ShowDescGUI();
                //show gui
                //show description gui
            }
        }
    }

    public void OnBeginDrag(BaseEventData data)
    {
        ChangeIconToHeldSprite();

        //change to this
        // Debug.Log("Item draggd");
        GameInput.Instance.SetSelectedIIGUI(this);
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
        GameInput.Instance.SetSelectedIIGUI(null);
    }

    public void OnPointerEnter(BaseEventData data)
    {
        EndTimer();
        ResetTimer();
        StartTimer();
    }

    public void OnPointerExit(BaseEventData data)
    {
        EndTimer();
        ResetTimer();
        HideDescGUI();
        //hide gui if displayed
    }

    private void StartTimer() {
        startTimer = true;
    }

    private void EndTimer()
    {
        startTimer = false;
    }
    private void ResetTimer()
    {
        timer = 0f;
    }

    private void ShowDescGUI()
    {
        if (!descriptionGUI.activeSelf)
        {
            if (!intDescGUI.TextSet)
            {
                intDescGUI.SetText(item);
            }
            descriptionGUI.SetActive(true);
        }
    }

    private void HideDescGUI()
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

    public void SetParameters(Interactible interactible, InvSlot iS)
    {
        item = interactible;
        itemSO = interactible.GetInteractibleSO();
        inventorySlot = iS;
        SetIcon();
    }

    public void FallPill()
    {
        if (caseOpened)
        {
            //drop
            item.GUIInteract();
            Debug.Log("pill fell");
            
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
