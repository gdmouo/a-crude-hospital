using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public static AttackController Instance { get; private set; }
    [SerializeField] private List<ProjectileLauncher> pLs;
    private Dictionary<Dir, ProjectileLauncher> pLDict;
    public Dictionary<Dir, ProjectileLauncher> PLDict {  get { return pLDict; } }

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
        pLDict = new Dictionary<Dir, ProjectileLauncher>();
        foreach (ProjectileLauncher p in pLs)
        {
            pLDict.Add(p.AttackingDir, p);
        }
    }
}
