using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    [SerializeField] private PlayerBackpack playerBackpack;
    [SerializeField] private List<HotbarSlotUI> hotbarSlotUIs;
    
    // Start is called before the first frame update
    private void Start()
    {
        if (playerBackpack == null)
        {
            PlayerCharacter p = PlayerCharacter.Instance;

            if (p != null)
            {
                PlayerBackpack b = p.GetPlayerBackpack();
                if (b != null)
                {
                    playerBackpack = b;
                }
            }
        }

        playerBackpack.OnHotbarItemChanged += PlayerBackpack_OnHotbarItemChanged;
        //Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    private void PlayerBackpack_OnHotbarItemChanged(object sender, PlayerBackpack.OnHotbarItemChangedEventArg e)
    {
        if (hotbarSlotUIs == null)
        {
            return;
        }

        int slot = e.slot;
        if (slot >= hotbarSlotUIs.Count)
        {
            return;
        }
        Pickup pickup = e.pickup;
        if (pickup != null)
        {
            HotbarSlotUI slotUI = GetSlotByNumber(slot);
            if (!slotUI.IsItemInSlot(pickup))
            {
                slotUI.SetItem(pickup);
            }
        }
        else
        {
            HotbarSlotUI slotUI = GetSlotByNumber(slot);
            slotUI.RemoveItem();
        }
        //
    }

    public HotbarSlotUI GetSlotByNumber(int i)
    {
        foreach (HotbarSlotUI h in hotbarSlotUIs)
        {
            if (h.SlotNumber == i)
            {
                return h;
            }
        }
        return null;
    }
}
