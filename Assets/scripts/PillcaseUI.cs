using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PillcaseUI : MonoBehaviour
{
    public static PillcaseUI Instance { get; private set; }
    [SerializeField] private RectTransform colliderRectTransform;
    [SerializeField] private Transform pillGUIParent;

    //private Dictionary<GameObject, GameObject> pills;
    private List<GameObject> pillsUIRepresentationsList;
    private List<PillSO> pillSOs;

    //private List<Pill> pills;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Menu instance found");
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public RectTransform GetCRT()
    {
        return colliderRectTransform;
    }

    public bool DepositPill(Pill pill)
    {
        //if (pills == null) pills = new Dictionary<Pill, GameObject>();
        if (pillsUIRepresentationsList == null) pillsUIRepresentationsList = new List<GameObject>();
        if (pillSOs == null) pillSOs = new List<PillSO>();

        if (pillsUIRepresentationsList.Count >= 9)
        {
            return false;
        }
        
        GameObject guiVisual = pill.GetPillGUIPrefab();
        guiVisual = Instantiate(guiVisual);
        guiVisual.transform.SetParent(pillGUIParent);
        guiVisual.GetComponent<RectTransform>().anchoredPosition = pillGUIParent.GetComponent<RectTransform>().anchoredPosition;
        pillSOs.Add(pill.PillSO);
        pillsUIRepresentationsList.Add(guiVisual);

        return true;
    }
    
    public List<PillSO> GetAndClearPils()
    {
        List<PillSO> toRet = new List<PillSO>(pillSOs);
       
        foreach (GameObject value in pillsUIRepresentationsList)
        {
            Destroy(value);
        }

        pillsUIRepresentationsList.Clear();
        pillSOs.Clear();

        return toRet;
    }

    public void RemovePill(Pill pill)
    {
        Destroy(pill.gameObject);
    }
}
