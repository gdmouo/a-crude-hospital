using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDescGUI : MonoBehaviour, IIntInvDescGUI
{
    public bool TextSet { get; protected set; }
    [SerializeField] protected TextMeshProUGUI itemName;
    [SerializeField] protected TextMeshProUGUI itemDescription;

    protected const string NAME_LABEL = "name: ";
    protected const string DESC_LABEL = "desc: ";

    protected InvSlot invSlot;

    private void Awake()
    {
        TextSet = false;
    }

    public virtual void SetParameters(Interactible inter, InvSlot iS)
    {
        invSlot = iS;
        InteractibleSO i = inter.GetInteractibleSO();
        itemName.text = NAME_LABEL + i.interactibleName;
        itemDescription.text = DESC_LABEL + ((inter as Pickup).GetItemDescription());
        TextSet = true;

        Vector2 os = new(192f,154f);

        //loc
        gameObject.GetComponent<RectTransform>().anchoredPosition = invSlot.GetIconFadedPosition() + os;
    }
}
