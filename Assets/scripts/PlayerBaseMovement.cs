using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseMovement : MonoBehaviour, IPlayerMovement
{
    /*
    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;

    private Rigidbody rb;
    private bool isGrounded;*/


    private void Update()
    {
        // Jump();
    }

    /*
    public void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump when space is pressed and player is on ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Reset Y velocity
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }*/

    public void Move(Vector2 inputVector, Vector3 cameraForward, Vector3 cameraRight, float moveSpeed, float playerRadius, float playerHeight)
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
    }

    public void Jump(bool value)
    {

    }
    private Vector3 GetMovementVector(Vector3 moveDir, Vector3 cameraForward, Vector3 cameraRight)
    {
        Vector3 forward = cameraForward;
        Vector3 right = cameraRight;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        float horizontalInput = moveDir.x;
        Debug.Log(horizontalInput);
        float verticalInput = moveDir.z;
        Vector3 moveDirection = (forward * verticalInput) + (right * horizontalInput);
        return moveDirection;
    }
}
