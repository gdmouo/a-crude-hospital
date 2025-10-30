using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float playerRadius = .7f;
    [SerializeField] private float playerHeight = 2f;

    /*
    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;

    private Rigidbody rb;
    private bool isGrounded;*/

    private IPlayerMovement playerMovement;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Player instance found");
        }
        Instance = this;
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void Jump()
    {
        playerMovement ??= gameObject.GetComponent<IPlayerMovement>();

        playerMovement.Jump(true);
    }

    public void StopJumping()
    {
        playerMovement ??= gameObject.GetComponent<IPlayerMovement>();

        playerMovement.Jump(false);
    }

    public void Move(Vector2 inputVector, Vector3 cameraForward, Vector3 cameraRight)
    {
        playerMovement ??= gameObject.GetComponent<IPlayerMovement>();

        playerMovement.Move(inputVector, cameraForward, cameraRight, moveSpeed, playerRadius, playerHeight);
    }
    public void Rotate(Vector3 input)
    {
        transform.eulerAngles = input;
    }
}
