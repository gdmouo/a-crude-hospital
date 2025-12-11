using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillBottle : Interactible
{
  //  [SerializeField] private Pill pill;
    [SerializeField] private GameObject pillPrefab;
    private Pill pill;
    public override void GUIInteract()
    {
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
        }
    }

}
