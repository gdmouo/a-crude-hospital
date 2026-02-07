using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldAttackController : MonoBehaviour
{
    public static OldAttackController Instance { get; private set; }
    [SerializeField] private List<OldProjectileLauncher> pLs;
    private Dictionary<Dir, OldProjectileLauncher> pLDict;
    public Dictionary<Dir, OldProjectileLauncher> PLDict {  get { return pLDict; } }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SortDict();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SortDict()
    {
        pLDict = new Dictionary<Dir, OldProjectileLauncher>();
        foreach (OldProjectileLauncher p in pLs)
        {
            pLDict.Add(p.AttackingDir, p);
        }
    }
}
