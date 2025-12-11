using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public event EventHandler<OnSelectedInteractibleChangedEventArgs> OnSelectedInteractibleChanged;
    public class OnSelectedInteractibleChangedEventArgs : EventArgs
    {
        public Interactible selectedInteractible;
    }
    public static Player Instance { get; private set; }

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float playerRadius = .7f;
    [SerializeField] private float playerHeight = 2f;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform interactibleHoldPoint;

    [Header("Raycast Settings")]
    [SerializeField] private float raycastRange;
    [SerializeField] private LayerMask interactLayer;

    private Interactible interactibleHolding;
    private Interactible selectedInteractible;

    private IPlayerMovement playerMovement;

    private Camera playerCamera;


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
        playerCamera = PlayerCamera.Instance.CameraObject;
    }

    private void Update()
    {
        RaycastCenterScreen();
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

    public void AccessInventory(int slot)
    {
        inventory.UseHotbar(slot, interactibleHolding);
    }

    public void InteractWithSelectedItem()
    {
        if (interactibleHolding != null)
        {
            interactibleHolding.InteractHolding(this);
        } else
        {
            if (selectedInteractible != null)
            {
                selectedInteractible.Interact(this);
            }
        }
    }

    private void RaycastCenterScreen()
    {
        Vector3 screenCenter = new(0.5f, 0.5f, 0f);
        Ray ray = playerCamera.ViewportPointToRay(screenCenter);

        // Perform the raycast
        if (Physics.Raycast(ray, out RaycastHit hit, raycastRange, interactLayer))
        {
            if (hit.transform.gameObject.TryGetComponent<Interactible>(out Interactible i))
            {
                if (selectedInteractible == null || (!GameObject.ReferenceEquals(selectedInteractible, i) && !GameObject.ReferenceEquals(interactibleHolding, i)))
                {
                    selectedInteractible = i;
                    OnSelectedInteractibleChanged?.Invoke(this, new OnSelectedInteractibleChangedEventArgs
                    {
                        selectedInteractible = selectedInteractible
                    });
                }
                //selectedInteractible.Interact(this);
            } else
            {
                selectedInteractible = null;
                OnSelectedInteractibleChanged?.Invoke(this, new OnSelectedInteractibleChangedEventArgs
                {
                    selectedInteractible = null
                });
            }
            //Debug.Log("Raycast hit: " + hit.collider.name + " at position: " + hit.point);
        }
        else
        {
            selectedInteractible = null;
            OnSelectedInteractibleChanged?.Invoke(this, new OnSelectedInteractibleChangedEventArgs
            {
                selectedInteractible = null
            });
            // If the ray did not hit anything within the specified range
        }
    }

    void OnDrawGizmos()
    {
        if (playerCamera != null)
        {
            Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0f);
            Ray ray = playerCamera.ViewportPointToRay(screenCenter);

            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray.origin, ray.direction * raycastRange);
        }
    }

    public void PickupItem(Interactible i)
    {
        interactibleHolding = i;
        i.SetParentToFollow(interactibleHoldPoint);
    }

    public void StoreItem(Interactible i)
    {
        inventory.AutofillInventory(i);
    }

    public void SetInteractibleHoldingToNUll()
    {
        interactibleHolding = null;
    }

    public Interactible GetInteractibleHolding()
    {
        return interactibleHolding;
    }

    public void GivePlayerPills(List<PillSO> pills)
    {
        foreach (PillSO pill in pills)
        {
            Debug.Log("took " + pill.pillName);
        }

        gameObject.GetComponent<PillLeProcessor>().ProcessPills(pills);
    }
}
