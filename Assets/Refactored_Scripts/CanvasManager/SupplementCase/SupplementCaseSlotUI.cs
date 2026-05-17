using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SupplementCaseSlotUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SupplementCompartmentDisplay compartmentDisplay;
    [SerializeField] private Image pillImage;
    [SerializeField] private int slotNumber = 0;

    private PillSO pillOccupying = null;
    private Pillcase pillCase = null;
    public int SlotNumber { get { return slotNumber; } }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (pillOccupying != null)
        {
            RemovePill();
            return;
        }

        InventorySlotUI i = InventoryDisplay.Instance.GetSelectedSlot();
        if (i == null) return;

        Pickup p = i.ItemOccupying;

        if (p.Type != PickupType.Pillcase) return;

        Pillcase pC = p as Pillcase;

        PillSO pS = pC.GetPill();

        if (pS == null) return;

        pillCase = pC;
        pillOccupying = pS;

        AddPill(pS);

        //as pillcase
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PillSO GetPillOccupying()
    {
        return pillOccupying;
    }

    private void RemovePill()
    {
        pillCase.IncPillCount();
        pillOccupying = null;
        pillCase = null;
        pillImage.sprite = null;
    }

    public void DestroyPill()
    {
        pillOccupying = null;
        pillCase = null;
        pillImage.sprite = null;
    }

    private void AddPill(PillSO pS)
    {
        pillImage.sprite = pS.pillSprite;
    }
}
