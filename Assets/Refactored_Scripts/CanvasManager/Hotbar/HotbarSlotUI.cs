using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarSlotUI : MonoBehaviour
{
    [SerializeField] private Image uiImage;
    [SerializeField] private int slotNumber;
    private Pickup itemOccupying;
    public int SlotNumber { get { return slotNumber; } }
    public Pickup ItemOccupying { get { return itemOccupying; } }

    public void SetItem(Pickup p)
    {
        itemOccupying = p;
        PickupUISO pUISO = p.GetUISO();
        if (pUISO != null)
        {
            uiImage.sprite = pUISO.hotbarIcon;
            uiImage.enabled = true;
        }
    }

    public void RemoveItem()
    {
        itemOccupying = null;
        uiImage.sprite = null;
        uiImage.enabled = false;
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
}
