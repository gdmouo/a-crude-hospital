using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillcaseUI : MonoBehaviour
{
    public static PillcaseUI Instance { get; private set; }
    [SerializeField] private RectTransform colliderRectTransform;

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
}
