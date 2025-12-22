using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractible
{
   // public Sprite GetIcon();
    public string GetName();
    public void Interact(Player player);
  //  public void InteractHolding(Player player);
}
