using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flopahhpickup : Interactible
{
    protected IntInvGUI intInvGUI;
    protected InteractibleSO interactibleSO;
    public Sprite GetIcon()
    {
        return (interactibleSO as ItemSO).sprite;
    }

    public Sprite GetHeldIcon()
    {
        return (interactibleSO as ItemSO).heldSprite;
    }

    /*
    public override void Interact(Player player)
    {
        player.StoreItem(this);
    }*/
    public virtual void InteractHolding(Player player)
    {
        Debug.Log("interact while holding");
    }

    public string GetItemDescription()
    {
        return (interactibleSO as ItemSO).itemDescription;
    }

    public virtual void GUIInteract()
    {

    }

    //set interactible
    public virtual void SetGUIIntParam(IntInvGUI i)
    {
        intInvGUI = i;
    }

    public override void Interact(Character character)
    {
        throw new System.NotImplementedException();
    }
}
