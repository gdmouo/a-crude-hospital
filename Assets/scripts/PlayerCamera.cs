using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public static PlayerCamera Instance { get; private set; }
    public Camera CameraObject { get { return playerCamera; } }

    [Header("Mouse Settings")]
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float clampAngle = 80f;
    [SerializeField] private bool FollowPlayerEnabled = true;
    [SerializeField] private Vector3 cameraOffset;

    [SerializeField] private Camera playerCamera;

    private Player player;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one FirstPersonCamera instance found");
        }
        Instance = this;
    }

    private void Start()
    {
        player = Player.Instance;
    }

    private void Update()
    {
        if (FollowPlayerEnabled)
        {
            FollowPlayer();
        }
    }

    public void Move(Vector2 lookInput)
    {
        transform.Rotate(Vector3.up, lookInput.x * sensitivity * Time.deltaTime, Space.World);
        lookInput.y = Mathf.Clamp(lookInput.y, -clampAngle, clampAngle);
        transform.Rotate(Vector3.right, -lookInput.y * sensitivity * Time.deltaTime, Space.Self);
        transform.eulerAngles = new(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
    }

    private void FollowPlayer()
    {
        Vector3 newPosition = player.transform.position + cameraOffset;
        transform.position = newPosition;
    }
}
