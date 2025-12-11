using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour, IInteractible
{
    [SerializeField] private InteractibleSO interactibleSO;

    [SerializeField] private int quantity = 0;
    public int Quantity { get { return quantity; } }
    
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

    public virtual void Interact(Player player)
    {
        player.StoreItem(this);
    }

    public virtual void InteractHolding(Player player)
    {
        Debug.Log("interact while holding");
    }

    public string GetItemName()
    {
        return interactibleSO.itemName;
    }

    public string GetItemDescription()
    {
        return interactibleSO.itemDescription;
    }

    public void SetParentToFollow(Transform t)
    {
        transform.parent = t;
        transform.localPosition = Vector3.zero;
    }

    public virtual void GUIInteract()
    {

    }

    public InteractibleSO GetInteractibleSO()
    {
        return interactibleSO;
    }

    public void DecreaseQuantity()
    {
        if (quantity > 0)
        {
            quantity--;
        }
    }

}
