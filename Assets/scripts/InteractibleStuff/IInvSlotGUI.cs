using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IInvSlotGUI
{
    public void OnBeginDrag(BaseEventData data);

    public void OnDrag(BaseEventData data);

    public void OnEndDrag(BaseEventData data);
    public void OnPointerEnter(BaseEventData data);
    public void OnPointerExit(BaseEventData data);
    public void SetIcon();
    public void SetParameters(Interactible interactible, InvSlot iS, ItemDescGUI iD);

    public void GUIHoldingInteract();
}
