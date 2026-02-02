using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PillBottleDescGUI : ItemDescGUI
{
    [SerializeField] private TextMeshProUGUI sideEffects;
    [SerializeField] private TextMeshProUGUI pillQuantity;

    private const string SE_LABEL = "side effects: ";
    private const string QTY_LABEL = "qty: ";


    //assumgin labelw
    public override void SetParameters(Interactible inter, InvSlot iS)
    {
        base.SetParameters(inter, iS);
     //   PillBottleSO i = inter.GetInteractibleSO() as PillBottleSO; 
       // itemName.text = NAME_LABEL + i.interactibleName;
       // itemDescription.text = DESC_LABEL + ((inter as Item).GetItemDescription());
      //  sideEffects.text = SE_LABEL + i.sideEffects;
        pillQuantity.text = QTY_LABEL + (inter as PillBottle).Quantity.ToString();
        //TextSet = true;
    }

    public void UpdatePillCount(int c)
    {
        pillQuantity.text = QTY_LABEL + c.ToString();
    }
}
