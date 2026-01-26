using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillBottle : Pickup
{
    [SerializeField] private int quantity;
    [SerializeField] private GameObject pillPrefab;
    private Pill pill;

    public int Quantity { get { return quantity; } }

    public Sprite GetOpenedIcon()
    {
        return (interactibleSO as PillBottleSO).openedSprite;
    }

    public string GetSideEffects()
    {
        return (interactibleSO as PillBottleSO).sideEffects;
    }

    public void DecreaseQuantity()
    {
        quantity--;
        if (intInvGUI != null)
        {
            PillBottleDescGUI po = intInvGUI.GetItemDescGUI() as PillBottleDescGUI;
            po.UpdatePillCount(quantity);
        }
    }

    public override void GUIInteract()
    {
        if (quantity > 0)
        {
            if (pill == null)
            {
                pill = pillPrefab.GetComponent<Pill>();
            }
            if (PillcaseUI.Instance.DepositPill(pill))
            {
                //quantity--;
                DecreaseQuantity();
            }
        }

        /*
        if (pill == null)
        {
            pill = pillPrefab.GetComponent<Pill>();
        }
        if (Quantity > 0)
        {
            if (PillcaseUI.Instance.DepositPill(pill))
            {
                DecreaseQuantity();
            }
            //update gui
        }*/
    }



}
