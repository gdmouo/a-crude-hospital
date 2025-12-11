using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntDescGUI : MonoBehaviour
{
    public bool TextSet { get; private set; }
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI sideEffects;
    [SerializeField] private TextMeshProUGUI pillQuantity;

    private const string NAME_LABEL = "name: ";
    private const string DESC_LABEL = "desc: ";
    private const string SE_LABEL = "side effects: ";
    private const string QTY_LABEL = "qty: ";

    private void Awake()
    {
        TextSet = false;
    }

    //assumgin label
    public void SetText(Interactible inter)
    {
        InteractibleSO i = inter.GetInteractibleSO();
        itemName.text = NAME_LABEL + i.itemName;
        itemDescription.text = DESC_LABEL + i.itemGUIDescription;
        sideEffects.text = SE_LABEL + i.sideEffects;
        pillQuantity.text = QTY_LABEL + inter.Quantity.ToString();
        TextSet = true;
    }

    
}
