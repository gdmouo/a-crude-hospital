using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.TextCore.Text;

public class PlayerCCMovement : MonoBehaviour, IPlayerMovement
{
    [Header("Jump Settings")]
    [SerializeField] private float gravity = -2;
    [SerializeField] private float jumpHeight = 2;

    [SerializeField] private Vector3 groundCheckOffset;
    [SerializeField] private float groundCheckSize;
    [SerializeField] private LayerMask groundCheckLayer;

    private CharacterController characterController;
    private Vector2 velocity;
    private bool jumping = false;

    private void Awake()
    {
        if (characterController == null)
        {
            characterController = gameObject.GetComponent<CharacterController>();
        }
    }

    private void Update()
    {
        HandleGravity();
    }

    public void Move(Vector2 inputVector, Vector3 cameraForward, Vector3 cameraRight, float moveSpeed, float playerRadius, float playerHeight)
    {
        Vector3 moveDirection = transform.right * inputVector.x + transform.forward * inputVector.y;
        characterController.Move(moveSpeed * Time.deltaTime * moveDirection);
    }

    public void Jump(bool value)
    { 
        if (value && IsGrounded())
        {
            jumping = true;
        } else
        {
            jumping = false;
        }
    }
    private void HandleGravity()
    {
        if (jumping)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        } else if (characterController.isGrounded && velocity.y < 0)
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

    //
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position - groundCheckOffset, groundCheckSize);
    }
}
