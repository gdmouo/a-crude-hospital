using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static Menu Instance { get; private set; }
    public bool SwitchedOn { get; private set; }

    [SerializeField] private GameObject backdrop;
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

    public bool Toggle()
    {
        if (backdrop.activeSelf)
        {
            backdrop.SetActive(false);
            SwitchedOn = false;
            return false;
        } else
        {
            backdrop.SetActive(true);
            SwitchedOn = true;
            return true;
        }
    }
}
