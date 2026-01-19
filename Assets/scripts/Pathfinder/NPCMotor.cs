using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
public class NPCMotor : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 3.5f;
    public float acceleration = 12f;
    public float turnSpeed = 12f;
    public float stoppingDistance = 0.25f;

    [Header("Gravity")]
    public float gravity = -20f;

    private CharacterController controller;
    private Vector3 velocity;          // includes vertical velocity
    private Vector3 planarVel;         // xz movement smoothing
    private Vector3? targetPos;        // current goal

    private Queue<Vector3> pathTargets;

    private bool enableMovement = false;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (enableMovement)
        {
            Move();
        }
    }

    public void ToggleMovement(bool b)
    {
        enableMovement = b;
    }

    // Optional helper for animation
    /*
    public float GetSpeed01()
    {
        float planarSpeed = new Vector3(planarVel.x, 0f, planarVel.z).magnitude;
        return Mathf.InverseLerp(0f, speed, planarSpeed);
    }*/

    public void SetTarget(Vector3 worldPos)
    {
        targetPos = worldPos;
    }
    public void ClearTarget()
    {
        targetPos = null;
    }

    private void Move()
    {
        Vector3 desiredPlanar = Vector3.zero;

        if (targetPos.HasValue)
        {
            Vector3 to = targetPos.Value - transform.position;
            to.y = 0f;

            float dist = to.magnitude;

            if (dist <= stoppingDistance)
            {
                //desiredPlanar = Vector3.zero;
                
                if (TryGetPathStep())
                {
                    return;
                } else
                {
                    desiredPlanar = Vector3.zero;
                }
                //fjldksjafkl
            }
            else
            {
                Vector3 dir = to / dist; // normalized
                desiredPlanar = dir * speed;

                // Turn toward movement direction
                if (dir.sqrMagnitude > 0.0001f)
                {
                    Quaternion desiredRot = Quaternion.LookRotation(dir);
                    transform.rotation = Quaternion.Slerp(
                        transform.rotation, desiredRot, turnSpeed * Time.deltaTime
                    );
                }
            }
        }

        // Smooth acceleration/deceleration
        planarVel = Vector3.MoveTowards(planarVel, desiredPlanar, acceleration * Time.deltaTime);

        // Gravity
        if (controller.isGrounded && velocity.y < 0f)
            velocity.y = -2f; // small stick-to-ground value

        velocity.y += gravity * Time.deltaTime;

        // Combine and move
        Vector3 move = planarVel;
        move.y = velocity.y;

        controller.Move(move * Time.deltaTime);
    }

    public void SetPath(List<Vector3> path)
    {
        pathTargets = new Queue<Vector3>();
        foreach (Vector3 p in path)
        {
            pathTargets.Enqueue(p);
        }
    }

    /*
    public bool TryGetPathStep()
    {
        if (pathTargets != null && pathTargets.Count > 0)
        {
            SetTarget(pathTargets.Dequeue());
            return true;
        }
        return false;
    }*/
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
