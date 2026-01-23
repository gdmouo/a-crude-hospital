using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatman : NPC
{
    public static Hatman Instance { get; private set; }
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
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //activate
    //settargetroom <- use separate class to generate whichroom
    //travel

    public override CharacterType GetCharacterType()
    {
        return CharacterType.NPC;
    }
    public void Activate()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            Activated = true;
        }
        /*
        if (!visualParent.activeSelf)
        {
            visualParent.SetActive(true);
            Activated = true;
        }*/
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

    public void TogglePausePath(bool b)
    {
        if (b)
        {
            npcMotor.PausePath();
        } else
        {
            npcMotor.UnpausePath();
        }
    }

    public void MovePos(Vector3 p)
    {
        transform.position = p;
    }

    //maybe in eed to clear target before the next one.. not sure

    public void Deactivate()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Triggerable>(out Triggerable b))
        {
            b.Interact(this);
        }
        /*
        if (other.gameObject.TryGetComponent<Triggerable>(out Triggerable b))
        {
            b.Interact(this);
        }*/

        //if inventory contains the music box, trigger

    }

}
