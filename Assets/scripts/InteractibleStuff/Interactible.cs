using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour, IInteractible
{
    [SerializeField] protected InteractibleSO interactibleSO;

   // [SerializeField] private int quantity = 0;
   // public int Quantity { get { return quantity; } }
    
    /*
    public Sprite GetIcon()
    {
        return interactibleSO.sprite;
    }

    public Sprite GetHeldIcon()
    {
        return interactibleSO.heldSprite;
    }

    public Sprite GetOpenedIcon()
    {
        return interactibleSO.openedSprite;
    }

    */

    public virtual void Interact(Player player)
    {
        //player.StoreItem(this);
    }

    /*

    public virtual void InteractHolding(Player player)
    {
        Debug.Log("interact while holding");
    }
    */

    public string GetName()
    {
        return interactibleSO.interactibleName;
    }

    public string GetHighlight()
    {
        return interactibleSO.interactingHighlight;
    }

    /*

    public string GetItemDescription()
    {
        return interactibleSO.interactingHighlight;
    }

    */

    public void SetParentToFollow(Transform t)
    {
        transform.parent = t;
        transform.localPosition = Vector3.zero;
    }

    /*
    public virtual void GUIInteract()
    {

    }*/

    public InteractibleSO GetInteractibleSO()
    {
        return interactibleSO;
    }

    /*
    public void DecreaseQuantity()
    {
        if (quantity > 0)
        {
            quantity--;
        }
    }*/

}
