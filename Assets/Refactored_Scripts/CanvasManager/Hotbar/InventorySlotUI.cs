using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private SlotIconUI icon;
    [SerializeField] private GameObject shadow;
    [SerializeField] private int slotNumber;
    [SerializeField] private InventoryDisplay display;
    private Pickup itemOccupying = null;
    public int SlotNumber { get { return slotNumber; } }
    public Pickup ItemOccupying { get { return itemOccupying; } }

    public void SetItem(Pickup p)
    {
       // Image iconImage = icon.GetComponent<Image>();
        Image shadowImage = shadow.GetComponent<Image>();

        itemOccupying = p;
        PickupUISO pUISO = p.GetUISO();

        if (pUISO != null)
        {
            // iconImage.sprite = pUISO.hotbarIcon;
            // iconImage.enabled = true;
            icon.Init(p);
            shadow.SetActive(true);
            shadowImage.sprite = pUISO.slotIcon;
        }
    }

    public void RemoveItem()
    {
        itemOccupying = null;
        shadow.SetActive(false);
        icon.Clear();

        if (display.GetSelectedSlot() != null)
        {
            display.SetSelectedSlot(null);
            // icon.Clear();
            icon.StopFollowingMouse();
            icon.SetIconLocalPosToZero();
        }
       // icon.sprite = null;
      //  uiImage.enabled = false;
    }

    public bool IsItemInSlot(Pickup p)
    {
        if (itemOccupying == null)
        {
            return false;
        }
        if (itemOccupying == p)
        {
            return true;
        }
        return false;
    }

    public void ToggleClick()
    {
        if (itemOccupying == null) return;

        if (itemOccupying.Type != PickupType.Pillcase) return;

        InventorySlotUI selectedIcon = display.GetSelectedSlot();

        if (selectedIcon != null && selectedIcon != this) return;

        if (selectedIcon != null && selectedIcon == this)
        {
            display.SetSelectedSlot(null);
           // icon.Clear();
            icon.StopFollowingMouse();
            icon.SetIconLocalPosToZero();
            //deselect
        } else if (selectedIcon == null)
        {
            display.SetSelectedSlot(this);
            icon.FollowMouse();
            //select
        }

    }

    public void PutAwayIcon()
    {
        // icon.Clear();
        icon.StopFollowingMouse();
        icon.SetIconLocalPosToZero();
        display.SetSelectedSlot(null);
    }
}
