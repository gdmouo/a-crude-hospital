using UnityEngine;

public class Pillcase : Pickup  
{
    [SerializeField] private PillSO pillSO;
    [SerializeField] private int pillCount = 0;
    [SerializeField] private MissionPickupID triggerID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PillSO GetPill()
    {
        if (pillCount <= 0) return null;

        pillCount--;

        return pillSO;
    }

    public void IncPillCount()
    {
        pillCount++;
    }

    //make it so it can only be picekd up after the other styff has ebjfwhaklchz.x, cl;ewkflefuoeli
    protected override void OnPickup()
    {
        string s = triggerID.ToString();
        MissionEvents.RaisePickupCollected(s);
    }

    public void ClearPillCount()
    {
        pillCount = 0;
    }
}
