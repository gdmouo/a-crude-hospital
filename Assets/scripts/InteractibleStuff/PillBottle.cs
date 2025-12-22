using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillBottle : Item
{
    [SerializeField] private int quantity;

  //  [SerializeField] private Pill pill;
    [SerializeField] private GameObject pillPrefab;
    private Pill pill;



    // [SerializeField] private int quantity = 0;
    public int Quantity { get { return quantity; } }

    public Sprite GetOpenedIcon()
    {
        return (interactibleSO as PillBottleSO).openedSprite;
    }

    /*
    public override void InteractHolding(Player player)
    {
        Debug.Log("take pill");
    }*/

    public string GetSideEffects()
    {
        return (interactibleSO as PillBottleSO).sideEffects;
    }

    /*
    public virtual void GUIInteract()
    {

    }*/

    /*
    public void DecreaseQuantity()
    {
        if (quantity > 0)
        {
            quantity--;
        }
    }*/
    public override void GUIInteract()
    {
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
