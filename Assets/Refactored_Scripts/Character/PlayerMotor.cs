using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : Motor
{
   // [Header("NPCMotor Exclusive Fields")]
    /*
    [Header("Jump Settings")]
    [SerializeField] private float jumpHeight = 2;
    [SerializeField] private Vector3 groundCheckOffset;
    [SerializeField] private float groundCheckSize;
    [SerializeField] private LayerMask groundCheckLayer;*/

  //  [Header("Collider Settings")]
   // [SerializeField] private float playerRadius = .7f;
    //[SerializeField] private float playerHeight = 2f;

   // [Header("Collider Settings")]

   // private bool jumping = false;

    private PlayerInput playerInput = null;

    public override void Move()
    {
        if (playerInput == null)
        {
            playerInput = driver as PlayerInput;
        }
        Vector2 inputVector = playerInput.GetMovementVectorNormalized();
        Vector3 moveDirection = transform.right * inputVector.x + transform.forward * inputVector.y;
        characterController.Move(moveSpeed * Time.deltaTime * moveDirection);
    }

    /*
    public void Jump(bool value)
    {
        
        if (value && IsGrounded())
        {
            jumping = true;
        }
        else
        {
            jumping = false;
        }
    }*/

    /*
    private void HandleGravity()
    {
        if (jumping)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        else if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to keep grounded
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private bool IsGrounded()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position - groundCheckOffset, groundCheckSize, groundCheckLayer);
        return hitColliders.Length != 0;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position - groundCheckOffset, groundCheckSize);
    }*/
}
