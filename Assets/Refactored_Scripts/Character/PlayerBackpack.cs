using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackpack : MonoBehaviour
{
    [SerializeField] private Transform toHideHotbarObj;
    private Dictionary<int, Pickup> hotbarItems;

    public event EventHandler<OnHotbarItemChangedEventArg> OnHotbarItemChanged;
    public class OnHotbarItemChangedEventArg : EventArgs
    {
        public int slot;
        public Pickup pickup;
    }

    // Start is called before the first frame update
    private void Start()
    {
        hotbarItems = new Dictionary<int, Pickup>()
        {
            { 0 , null },
            { 1 , null },
            { 2 , null }
        };
    }

    public bool TryInsertItem(Pickup p)
    {
        int toPut = GetFirstEmptySlot(hotbarItems);
        if (toPut != -1)
        {
           // Debug.Log("EHLLOOAOAOOAO");
            OnHotbarItemChanged?.Invoke(this, new OnHotbarItemChangedEventArg
            {
                
                slot = toPut, pickup = p
            });
            hotbarItems[toPut] = p;
            return true;
        }
        //updare da hotabox
        return false;
    }

    public Transform GetHotbarHidePar()
    {
        return toHideHotbarObj;
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

        //is full
        return -1;

    }
}
