using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatman : MonoBehaviour
{
    public static Hatman Instance { get; private set; }
    [SerializeField] private GameObject visualParent;
    [SerializeField] private NPCMotor npcMotor;
    public bool Activated { get; private set; }

    private void Awake()
    {
        Instance = this;
        Activated = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //activate
    //settargetroom <- use separate class to generate whichroom
    //travel

    public void Activate()
    {
        if (!visualParent.activeSelf)
        {
            visualParent.SetActive(true);
            Activated = true;
        }
    }
    public void SetDest(Vector3 l)
    {
      //  Debug.Log("djksal");
        List<Vector3> vectorPath = PathfindingSystem.Instance.GetShortestPathAsVectors(transform.position, l);
       // Debug.Log("wo");
        npcMotor.SetPath(vectorPath);
    }

    public void StartPath()
    {
        npcMotor.ToggleMovement(true);
        bool b = npcMotor.TryGetPathStep();
    }

    //maybe in eed to clear target before the next one.. not sure

    public void Deactivate()
    {
        if (visualParent.activeSelf)
        {
            visualParent.SetActive(false);
            Activated = false;
        }
    }

    public void SetBackToHallwayStartPos()
    {
        npcMotor.ClearTarget();
        npcMotor.ToggleMovement(false);
        transform.position = HallwayManager.Instance.HatmanHallwayStartPos;
        Deactivate();
    }


}
