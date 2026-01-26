using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : Character
{
    public event EventHandler<OnSelectedInteractibleChangedEventArgs> OnSelectedInteractibleChanged;
    public class OnSelectedInteractibleChangedEventArgs : EventArgs
    {
        public Interactible selectedInteractible;
    }
    public static Player Instance { get; private set; }

    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform interactibleHoldPoint;

    [Header("Raycast Settings")]
    [SerializeField] private float raycastRange;
    [SerializeField] private LayerMask interactLayer;

    private Pickup itemHolding;
    private Interactible selectedInteractible;

    private IPlayerMovement playerMovement;

    private Camera playerCamera;

    public Room CurrentRoom { get; private set; }
    public Inventory Inventory { get { return inventory;  } }


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
        CurrentRoom = Room.HOSPITAL_RECEPTION;
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

       // playerMovement.Move(inputVector, cameraForward, cameraRight,);
    }
    public void Rotate(Vector3 input)
    {
        transform.eulerAngles = input;
    }

    public void AccessInventory(int slot)
    {
        inventory.UseHotbar(slot, itemHolding);
    }

    public void InteractWithSelectedItem()
    {
        if (itemHolding != null)
        {
            itemHolding.InteractHolding(this);
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
    
        if (Physics.Raycast(ray, out RaycastHit hit, raycastRange, interactLayer))
        {
            if (hit.transform.gameObject.TryGetComponent<Interactible>(out Interactible i))
            {
                if (selectedInteractible == null || (!GameObject.ReferenceEquals(selectedInteractible, i) && !GameObject.ReferenceEquals(itemHolding, i)))
                {
                    selectedInteractible = i;
                    OnSelectedInteractibleChanged?.Invoke(this, new OnSelectedInteractibleChangedEventArgs
                    {
                        selectedInteractible = selectedInteractible
                    });
                }
            } else
            {
                selectedInteractible = null;
                OnSelectedInteractibleChanged?.Invoke(this, new OnSelectedInteractibleChangedEventArgs
                {
                    selectedInteractible = null
                });
            }
        }
        else
        {
            selectedInteractible = null;
            OnSelectedInteractibleChanged?.Invoke(this, new OnSelectedInteractibleChangedEventArgs
            {
                selectedInteractible = null
            });
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
        itemHolding = (Pickup) i;
        i.SetParentToFollow(interactibleHoldPoint);
    }

    public void StoreItem(Interactible i)
    {
        inventory.AutofillInventory(i);
    }

    public void SetInteractibleHoldingToNUll()
    {
        itemHolding = null;
    }

    public Interactible GetInteractibleHolding()
    {
        return itemHolding;
    }

    public void GivePlayerPills(List<PillSO> pills)
    {
        foreach (PillSO pill in pills)
        {
            Debug.Log("took " + pill.pillName);
        }

        gameObject.GetComponent<PillLeProcessor>().ProcessPills(pills);
    }

    public override CharacterType GetCharacterType()
    {
        return CharacterType.Player;
    }

    public override void CharacterTriggerFunction(Collider other)
    {
        if (other.gameObject.TryGetComponent<PassThrough>(out PassThrough b))
        {
            b.Interact(this);
        }
    }
}
