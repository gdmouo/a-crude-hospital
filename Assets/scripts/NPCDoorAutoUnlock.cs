using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCDoorAutoUnlock : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private Transform behindPoint;
    [SerializeField] private Transform frontPoint;

    private void Update()
    {
        /*
        if (doorOpenSequenceStarted)
        {
            if (door.CheckIfFullyOpened())
            {
                if (npcWhomEntered != null)
                {
                    npcWhomEntered.TogglePausePath(false);
                }
                doorOpenSequenceStarted=false;
            }
        }*/
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("DJASKOLHNDLZKLCJZXM>CKN");
        if (other.gameObject.CompareTag("NPC"))
        {
            if (!door.IsOpen)
            {
                door.ToggleDoor();
            }
        }
        /*
        Debug.Log("hyahs");
        if (other.gameObject.CompareTag("NPC"))
        {
            if (other.TryGetComponent<NPC>(out NPC npc))
            {
                npcWhomEntered = npc;
                MoveNPCToPoint(npc);
                ToggleDoor(true);
            } else
            {
                Debug.Log("fart");
            }
        }*/
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {

            if (door.IsOpen)
            {
                door.ToggleDoor();
            }
        }
    }

    /*
    private void ToggleDoor(bool didNPCEnter)
    {
        if (didNPCEnter)
        {
            if (!door.IsOpen)
            {
                door.ToggleDoor();
            }
        } else
        {
            if (door.IsOpen)
            {
                door.ToggleDoor();
            }
        }
    }

    private void MoveNPCToPoint(NPC npc)
    {
        float distToFront = Vector3.Distance(npc.transform.position, frontPoint.position);
        float distToBack = Vector3.Distance(npc.transform.position, behindPoint.position);
        Vector3 toPlace = distToFront < distToBack ? frontPoint.position : behindPoint.position;
        npc.TogglePausePath(true);
        npc.SetDest(toPlace);
    }*/
}


