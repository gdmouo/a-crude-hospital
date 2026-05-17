using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotIconUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private InventorySlotUI inventorySlotUI;
    public void OnPointerClick(PointerEventData eventData)
    {
        inventorySlotUI.ToggleClick();
    }

[SerializeField] private Image image;
    private Pickup item;

    private RectTransform rt;

    private bool followMouseEnabled = false;

    void Awake()
    {
        rt = image.GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        if (followMouseEnabled)
        {
            rt.position = Input.mousePosition;
        }
    }
    public void Init(Pickup pickup)
    {
        item = pickup;

        PickupUISO pUISO = pickup.GetUISO();

        if (pUISO == null) return;

        image.sprite = pUISO.slotIcon;
    }

    public void Clear()
    {
        item = null;

        image.sprite = null;
    }

    public void FollowMouse()
    {
        followMouseEnabled = true;
    }

    public void StopFollowingMouse()
    {
        followMouseEnabled = false;
    }

    public void SetIconLocalPosToZero()
    {
        rt.localPosition = Vector3.zero;
    }
}
