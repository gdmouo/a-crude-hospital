using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillLeProcessor : MonoBehaviour
{
    [SerializeField] private PillSO benadrylPill;
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
                pcDict.Add(pill.pillName, 1);
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
        hatmanDict.Add(benadrylPill.name, 9);

        foreach (KeyValuePair<string, int> kvp in pcDict)
        {
            if (pcDict.ContainsKey(kvp.Key))
            {
                if (kvp.Value == pcDict[kvp.Key])
                {

                } else
                {
                    return false;
                }
            }
        }

        //check count optionally

        return true;
    }

    private void TriggerHatmanEvent()
    {
        Debug.Log("hatman event triggered");
    }


}
