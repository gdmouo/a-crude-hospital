using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : CharacterSensor
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private float raycastRange;
    private Interactible selectedInteractible = null;
    public Interactible SelectedInteractible { get { return selectedInteractible; } }
    private PlayerCharacter player = null;


    protected override void RaycastSense()
    {
        if (player == null)
        {
            player = character as PlayerCharacter;
        }

        Vector3 screenCenter = new(0.5f, 0.5f, 0f);
        Ray ray = playerCamera.ViewportPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, raycastRange, interactLayer))
        {
            if (hit.transform.gameObject.TryGetComponent<Interactible>(out Interactible i))
            {

                if (selectedInteractible == null || (!GameObject.ReferenceEquals(selectedInteractible, i) && !GameObject.ReferenceEquals(player.ItemHolding, i)))
                {
                    selectedInteractible = i;
                }
      
                }
                else
                {
                    
                    selectedInteractible = null;
                }
            }
            else
            {
    
            selectedInteractible = null;
         }
    }

    private void OnDrawGizmos()
    {
        if (playerCamera != null)
        {
            Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0f);
            Ray ray = playerCamera.ViewportPointToRay(screenCenter);

            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray.origin, ray.direction * raycastRange);
        }
    }
}
