using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class NPCDoorAutoUnlock : PassThrough
{
    [SerializeField] private Door door;
    [SerializeField] private GameObject doorCollisionObject;
    [SerializeField] private Transform behindPoint;
    [SerializeField] private Transform frontPoint;
    [SerializeField] private BoxCollider thisBoxCollider;


    private GameObject targetEntering = null;
    private Bounds areaBounds;
   

    void Start()
    {
        if (thisBoxCollider != null)
        {
            areaBounds = thisBoxCollider.bounds;
        }
    }

    private void Update()
    {
        if (targetEntering != null)
        {
            if (CheckIfTargetIsInsideThisZone())
            {
                targetEntering = null;
                ToggleDoorCollider(false);
            } 
        }
    }

    public override void Interact(Character character)
    {
        if (character.GetCharacterType() == CharacterType.NPC)
        {
            targetEntering = character.gameObject;
            ToggleDoorCollider(true);
            //
        }
    }

    public void ToggleDoorCollider(bool op)
    {
        if (doorCollisionObject != null)
        {
            if (doorCollisionObject.TryGetComponent<BoxCollider>(out BoxCollider b))
            {
                b.enabled = op;
            }
        }
    }

    private bool CheckIfTargetIsInsideThisZone()
    {
        if (targetEntering == null)
        {
            return false;
        }
        if (areaBounds.Contains(targetEntering.transform.position))
        {
            return true;
            // target is inside
        }
        return false;
    }
}


