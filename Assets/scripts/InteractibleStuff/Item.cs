using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Item : Interactible
{

    // [SerializeField] private int quantity = 0;
    // public int Quantity { get { return quantity; } }

    
    public Sprite GetIcon()
    {
        return (interactibleSO as ItemSO).sprite;
    }

    public Sprite GetHeldIcon()
    {
        return (interactibleSO as ItemSO).heldSprite;
    }


    public override void Interact(Player player)
    {
        player.StoreItem(this);
    }
    public virtual void InteractHolding(Player player)
    {
        Debug.Log("interact while holding");
    }

    public string GetItemDescription()
    {
        return (interactibleSO as ItemSO).itemDescription;
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


    public virtual void GUIInteract()
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
