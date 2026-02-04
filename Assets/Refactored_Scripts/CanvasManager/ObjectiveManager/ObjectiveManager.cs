using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected ObjectiveUI ui;
    public static ObjectiveManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if o is held down, keep active only until realeased
    }

    public ObjectiveUI GetObjectiveUI()
    {
        return ui;
    }

    /*
    public void ToggleObjectiveVisibility(bool b)
    {
        ui.SetOpen(b);
    }*/

    //set awake then fade
    //set wake
    //turn off
}
