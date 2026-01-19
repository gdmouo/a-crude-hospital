using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillLeProcessor : MonoBehaviour
{
    [SerializeField] private PillSO benadrylPill;
    [SerializeField] private int hatmanPillPreCond = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessPills(List<PillSO> pills)
    {
        Dictionary<string, int> pcDict = new Dictionary<string, int>();

        foreach (PillSO pill in pills)
        {
            if (!pcDict.ContainsKey(pill.pillName))
            {
                pcDict.Add(pill.pillName, 0);
            }
            pcDict[pill.pillName]++;
        }

        CheckWhichEvent(pcDict);

    }

    private void CheckWhichEvent(Dictionary<string, int> pcDict)
    {
        if (CheckHatmanEvent(pcDict))
        {
            //trigger
            TriggerHatmanEvent();
        }
    }

    private bool CheckHatmanEvent(Dictionary<string, int> pcDict)
    {
        Dictionary<string, int> hatmanDict = new Dictionary<string, int>();
        hatmanDict.Add(benadrylPill.pillName, hatmanPillPreCond);

        foreach (KeyValuePair<string, int> kvp in pcDict)
        {
            //v currently will only trigger event for the first satisfied combo it detects
            if (pcDict.ContainsKey(kvp.Key))
            {
               // Debug.Log(kvp.Key);
                //Debug.Log(benadrylPill.pillName);
                if (kvp.Value == hatmanDict[kvp.Key])
                {
                    return true;
                } 
            }
        }

        Debug.Log("no event triggered.");

        //check count optionally

        return false;
    }

    private void TriggerHatmanEvent()
    {
        HallwayGameManager.Instance.EnableKeyObjects();
        //Debug.Log("hatman event triggered");
    }


}
