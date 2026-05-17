using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackpack : MonoBehaviour
{
    [SerializeField] private Transform toHideHotbarObj;
    private Dictionary<int, Pickup> inventoryItems;

    public event EventHandler<OnHotbarItemChangedEventArg> OnHotbarItemChanged;
    public class OnHotbarItemChangedEventArg : EventArgs
    {
        public int slot;
        public Pickup pickup;
    }

    // Start is called before the first frame update
    private void Start()
    {
        inventoryItems = new Dictionary<int, Pickup>()
        {
            { 0 , null },
            { 1 , null },
            { 2 , null }
        };
    }

    public bool TryInsertItem(Pickup p)
    {
        int toPut = GetFirstEmptySlot(inventoryItems);

        //

        if (toPut != -1)
        {
            OnHotbarItemChanged?.Invoke(this, new OnHotbarItemChangedEventArg
            {
                
                slot = toPut, pickup = p
            });
            inventoryItems[toPut] = p;
            p.SetSlotNumber(toPut);
            return true;
        }
        return false;
    }

    public void SelectSlot(int i)
    {
        Pickup pickup = inventoryItems[i];
        if (pickup != null)
        {
            if (pickup.IsHeld)
            {
                PlayerCharacter.Instance.DropItem(inventoryItems[i]);
                HotbarManager.Instance.DarkenSlot(-1);
            } else
            {
                PlayerCharacter.Instance.HoldItem(inventoryItems[i]);
                HotbarManager.Instance.DarkenSlot(i);
            }
        }
    }

    public Transform GetHotbarHidePar()
    {
        return toHideHotbarObj;
    }

    public Dictionary<int, Pickup> GetInventoryItems()
    {
        return inventoryItems;
    }

    private int GetFirstEmptySlot(Dictionary<int, Pickup> d)
    {
        if (d.Count != 3)
        {
            return -1;
        }

        foreach (KeyValuePair<int, Pickup> pair in d)
        {
            if (pair.Value == null)
            {
                return pair.Key;
            }
        }
        return -1;

    }

}
