using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTest : MonoBehaviour
{
    /*
    public float gravityStrength = 9.81f; // The strength of gravity
    private Vector3 currentVelocity = Vector3.zero; // Tracks the object's current velocity

    private float fallDirection = 0f;

    void Update()
    {
        // Apply gravity
        currentVelocity.y -= gravityStrength * Time.deltaTime;

        // Move the object based on its velocity
        transform.position += currentVelocity * Time.deltaTime;

        Vector3 moveDir = new(0f, fallDirection, 0f);

        float moveDistance = gravityStrength * Time.deltaTime;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
            }
        }

        if (canMove)
        {
            transform.position += GetMovementVector(moveDir, cameraForward, cameraRight) * moveDistance;
        }

        isWalking = moveDir != Vector3.zero;

        // Optional: Add collision detection if needed
        // (e.g., using Raycasting to check for ground collision and reset velocity)
        // For example:
        // RaycastHit hit;
        // if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
        // {
        //     if (currentVelocity.y < 0)
        //     {
        //         currentVelocity.y = 0;
        //         transform.position = new Vector3(transform.position.x, hit.point.y + 0.05f, transform.position.z); // Adjust for object height
        //     }
        // }
    }
    /*
    public void Move(Vector2 inputVector, Vector3 cameraForward, Vector3 cameraRight)
    {
        Vector3 moveDir = new(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
            }
        }

        if (canMove)
        {
            transform.position += GetMovementVector(moveDir, cameraForward, cameraRight) * moveDistance;
        }

        isWalking = moveDir != Vector3.zero;
    }*/
}
