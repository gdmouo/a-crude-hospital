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
            p.SetSlotNumber(toPut);
            return true;
        }
        //updare da hotabox
        return false;
    }

    public void SelectSlot(int i)
    {
        /*
        Pickup iHolding = PlayerCharacter.Instance.ItemHolding;
        if (iHolding != null)
        {
            PlayerCharacter.Instance.DropItem(iHolding);
            HotbarManager.Instance.DarkenSlot(-1);
        }
        */

        //check if playercharacter is holding item

        Pickup pickup = hotbarItems[i];
        if (pickup != null)
        {
            if (pickup.IsHeld)
            {
                PlayerCharacter.Instance.DropItem(hotbarItems[i]);
                HotbarManager.Instance.DarkenSlot(-1);
            } else
            {
                PlayerCharacter.Instance.HoldItem(hotbarItems[i]);
                HotbarManager.Instance.DarkenSlot(i);
                Debug.Log("holding item at slot " + i);
            }
        } else
        {
            

            //
            Debug.Log("no item at slot " + i);
        }



        //ubotpaniimal
        /*
        foreach (KeyValuePair<int, Pickup> pair in hotbarItems)
        {
            if (pair.Value != null)
            {
                pair.Value.TogglePhysical(false);
            }
        }

        Pickup pickup = hotbarItems[i];
        if (pickup != null)
        {
            pickup.TogglePhysical(true);
            HotbarManager.Instance.DarkenSlot(i);
        }*/

        //if slot item is already being held, put item away
        //if not, hold, reset all being held
        //also update player on item holding

        //dematerialize all other slot items incase
        //materialize selected slot item
        //highlight em too
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

    //selectitem
}
