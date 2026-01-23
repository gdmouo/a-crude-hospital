using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractible
{
   // public Sprite GetIcon();
    public string GetName();
    public void Interact(Player player);

    public void Interact(Character character);
  //  public void InteractHolding(Player player);
}
