using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractible
{

    public string GetName();
    public void Interact(Character character);
  //  public void InteractHolding(Player player);
}
