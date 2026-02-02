using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMotor : CharacterMotor
{
    [Header("NPCMotor Exclusive Fields")]
    [SerializeField] private float acceleration = 12f;
    [SerializeField] private float turnSpeed = 12f;
    [SerializeField] private float stoppingDistance = 0.25f;
    
    private Vector3 planarVel;      
    private Vector3? targetPos;       

    private Queue<Vector3> pathTargets;

    private bool enableMovement = false;

    private bool pathPaused = false;

    protected override void OnUpdate()
    {
        if (!enableMovement)
        {
            return;
        }
        base.OnUpdate();
    }

    public override void Move()
    {
        if (pathPaused)
        {
            return;
        }
        Vector3 desiredPlanar = Vector3.zero;

        if (targetPos.HasValue)
        {
            Vector3 to = targetPos.Value - transform.position;
            to.y = 0f;

            float dist = to.magnitude;

            if (dist <= stoppingDistance)
            {
                if (TryGetPathStep())
                {
                    return;
                } else
                {
                    desiredPlanar = Vector3.zero;
                }
            }
            else
            {
                Vector3 dir = to / dist;
                desiredPlanar = dir * moveSpeed;

                if (dir.sqrMagnitude > 0.0001f)
                {
                    Quaternion desiredRot = Quaternion.LookRotation(dir);
                    transform.rotation = Quaternion.Slerp(
                        transform.rotation, desiredRot, turnSpeed * Time.deltaTime
                    );
                }
            }
        }

        planarVel = Vector3.MoveTowards(planarVel, desiredPlanar, acceleration * Time.deltaTime);

        if (characterController.isGrounded && velocity.y < 0f)
            velocity.y = -2f; 

        velocity.y += gravity * Time.deltaTime;

        Vector3 move = planarVel;
        move.y = velocity.y;

        characterController.Move(move * Time.deltaTime);
    }

    public void ToggleMovement(bool b)
    {
        enableMovement = b;
    }

    public void SetTarget(Vector3 worldPos)
    {
        targetPos = worldPos;
    }
    public void ClearTarget()
    {
        targetPos = null;
    }

    public void SetPath(List<Vector3> path)
    {
        pathTargets = new Queue<Vector3>();
        foreach (Vector3 p in path)
        {
            pathTargets.Enqueue(p);
        }
    }

    public bool TryGetPathStep()
    {
        if (pathTargets != null && pathTargets.Count > 0)
        {
            SetTarget(pathTargets.Dequeue());
            return true;
        }
        return false;
    }
}
