using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactible
{
    public float openAngle = 90f; // The angle the door rotates to open
    public float rotationSpeed = 2f; // How fast the door opens/closes

    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Awake()
    {
        closedRotation = transform.localRotation; // Store the initial (closed) rotation
        openRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y + openAngle, transform.localEulerAngles.z); // Calculate open rotation
    }

    void Update()
    {

    }

    public void ToggleDoor()
    {
        isOpen = !isOpen; // Toggle the door state
        StopAllCoroutines(); // Stop any ongoing rotation
        StartCoroutine(RotateDoor(isOpen ? openRotation : closedRotation));
    }

    IEnumerator RotateDoor(Quaternion targetRotation)
    {
        while (Quaternion.Angle(transform.localRotation, targetRotation) > 0.01f)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
            yield return null; // Wait for the next frame
        }
        transform.localRotation = targetRotation; // Ensure the rotation is exactly at the target
    }
    public override void Interact(Player player)
    {
        ToggleDoor();
    }
}
