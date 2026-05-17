using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class SupplementCompartmentDisplay : MonoBehaviour
{
    [SerializeField] private List<SupplementCaseSlotUI> supplementCaseSlotUIs;
    [SerializeField] private PillProcessor pillProcessor;
    //
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SupplementCaseSlotUI GetSlotUIByIndex(int i)
    {
        foreach (SupplementCaseSlotUI slot in supplementCaseSlotUIs)
        {
            if (slot.SlotNumber == i) return slot;
        }

        return null;
    }

    public void ConsumeFunction()
    {
        // if (CheckForBarkadrylSuccess()) return;
        //
        //
        pillProcessor.ProcessPills(this);

    }

    public void RemoveAllPills()
    {
        foreach (SupplementCaseSlotUI slot in supplementCaseSlotUIs)
        {
            if (slot.GetPillOccupying() != null)
            {
                slot.DestroyPill();
            }
        }
    }
    //
}
