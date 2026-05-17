using UnityEngine;

public class PillProcessor : MonoBehaviour
{
    [SerializeField] private PillSO barkadrylPillSO;

    //make it so it can only be picekd up after the other styff has ebjfwhaklchz.x, cl;ewkflefuo
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void ProcessPills(SupplementCompartmentDisplay s)
    {
        if (CheckForBarkadryl(s))
        {
            s.RemoveAllPills();
            CloseInventory();
            //clear pills in s
            //close inventory

            MissionEvents.RaiseSequenceCompleted("ConsumedBarkadrylProperlyEvent");
        } 
    }

    private void CloseInventory()
    {
        StateManager g = StateManager.Instance;

        if (g != null)
        {
            g.ToggleState(GameStateType.Inventory);
        }
    }

    private bool CheckForBarkadryl(SupplementCompartmentDisplay s)
    {
        for (int i = 0; i < 9; i++)
        {
            PillSO p = s.GetSlotUIByIndex(i).GetPillOccupying();

            if (i == 4 ||  i == 6 || i == 7 || i == 8)
            {
                if (p != null)
                {
                    if (p.pillID != barkadrylPillSO.pillID) return false;
                } else
                {
                    return false;
                }
            } else
            {
                if (p != null) return false;
            }
        }
        //
        return true;
    }
}
