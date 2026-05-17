using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private List<InventorySlotUI> inventorySlotUIs;

    //
    private InventorySlotUI slotSelected = null;
    //slots
    //ui slots

    public static InventoryDisplay Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //call playerbackpack

    //
    public InventorySlotUI GetSelectedSlot()
    {
        return slotSelected;
    }
    public void SetSelectedSlot(InventorySlotUI i)
    {
        slotSelected = i;
    }
    public void OnActivate()
    {
        PlayerCharacter player = PlayerCharacter.Instance;
        PlayerBackpack pB = player.GetPlayerBackpack();
        Dictionary<int, Pickup> inventoryItems = pB.GetInventoryItems();

        foreach (KeyValuePair<int, Pickup> item in inventoryItems)
        {
            if (item.Value == null) return;
            InventorySlotUI i = GetSlotUIByIndex(item.Key);
            i.SetItem(item.Value);
        }
        //display
    }

    public void OnDeactivate()
    {
        InventorySlotUI selectedSlot = GetSelectedSlot();
        if (selectedSlot != null)
        {
            selectedSlot.PutAwayIcon();
        }

        foreach (InventorySlotUI i in inventorySlotUIs)
        {
            i.RemoveItem();
        }
    }
    
    private InventorySlotUI GetSlotUIByIndex(int i)
    {
        foreach (InventorySlotUI slot in inventorySlotUIs)
        {
            if (slot.SlotNumber == i) return slot;
        }

        return null;
    }
}
