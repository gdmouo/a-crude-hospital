using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireall : MonoBehaviour
{
    [SerializeField] private List<OldProjectileLauncher> pLs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireAll()
    {
        foreach (OldProjectileLauncher p in pLs)
        {
            //p.FireProjectile();
        }
    }
}
