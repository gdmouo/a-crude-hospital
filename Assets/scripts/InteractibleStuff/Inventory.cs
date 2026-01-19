using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<int, InvSlot> inventorySlots;
    private InvSlot currentSlotEmphasized;
    // Start is called before the first frame update
    void Start()
    {
        //InitializeInventory();
        inventorySlots = gameObject.GetComponent<InventoryGenerator>().GenerateInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if inventory contains beatbox
    public bool CheckForBattleBox()
    {
        string BATTLE_BOX_NAME = "Battle Mechanic";
        foreach (InvSlot slot in inventorySlots.Values)
        {
            if (slot.Item != null && slot.Item.GetName() == BATTLE_BOX_NAME)
            {
                return true;
            }
        }
        return false;
    }

    public void UseHotbar(int slot, Interactible i)
    {
        if (slot > 3)
        {
            return;
        }

        if (inventorySlots[slot].Item != null)
        {
            //if item is in slot
            if (i != null)
            {
                if (inventorySlots[slot].Emphasized)
                {
                    currentSlotEmphasized.Lighten();
                    currentSlotEmphasized = null;
                }

               
                //if item in hand is equal to slot item then die
                if (GameObject.ReferenceEquals(Player.Instance.GetInteractibleHolding(), inventorySlots[slot].Item))
                {
                    inventorySlots[slot].Store(i);
                }
                //do nothing
            }
            else
            {
                //if no item in hand
                if (!inventorySlots[slot].Item.gameObject.activeSelf)
                {
                    inventorySlots[slot].Item.gameObject.SetActive(true);
                }
                Player.Instance.PickupItem(inventorySlots[slot].Item);
                if (inventorySlots[slot].Item != null)
                {
                    currentSlotEmphasized = inventorySlots[slot];
                    currentSlotEmphasized.Emphasize();
                }
            }
        } else
        {
            //if slot is available
            if (i != null)
            {
                //if item in hand
                inventorySlots[slot].Store(i);
            } else
            {
                //if no item in hand
                //do nothing
                if (inventorySlots[slot].Emphasized)
                {
                    currentSlotEmphasized.Lighten();
                    currentSlotEmphasized = null;
                }
            }

        }
    }

    public void AutofillInventory(Interactible i)
    {
        int iCount = inventorySlots.Count;
        for (int slot = 0; slot < iCount; slot++)
        {
            if (inventorySlots.ContainsKey(slot))
            {
                if (inventorySlots[slot].Item == null)
                {
                    inventorySlots[slot].Store(i);
                    return;
                }
            }
        }
    }
}
