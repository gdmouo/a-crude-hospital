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
    }
    public void SetDest(Vector3 l)
    {
        List<Vector3> vectorPath = PathfindingSystem.Instance.GetShortestPathAsVectors(transform.position, l);
        npcMotor.SetPath(vectorPath);
    }

    public void StartPath()
    {
        npcMotor.ToggleMovement(true);
        bool b = npcMotor.TryGetPathStep();
    }
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

    public override void CharacterTriggerFunction(Collider other)
    {
        if (other.gameObject.TryGetComponent<PassThrough>(out PassThrough b))
        {
            b.Interact(this);
        }
    }

}
