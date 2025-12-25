using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.EventSystems;

public class MouseController : MonoBehaviour
{
    /*
    private PlayerInputActions playerInputActions;
    private Vector2 mouseInput;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Menu instance found");
        }
        //Instance = this;

        playerInputActions = new PlayerInputActions();


        playerInputActions.Player.Enable();
        playerInputActions.Player.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();
        playerInputActions.Player.Look.canceled += ctx => mouseInput = Vector2.zero; // Reset when mouse stops
        playerInputActions.Player.Click.performed += OnClick;
    }

    private void Start()
    {
        player = Player.Instance;
        firstPersonCamera = PlayerCamera.Instance;
        pause = Pause.Instance;
        backpack = Backpack.Instance;
        lockMouse = gameObject.GetComponent<LockMouse>();
        lockMouse.Toggle(false);
    }

    private void OnClick(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        player.InteractWithSelectedItem();
    }

    private void Update()
    {
        if (!playerControlsDisabled)
        {
  
        }
    }

    public bool IsMouseHolding()
    {
        return playerInputActions.Player.Click.IsPressed();
    }


    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer)
                return true;
        }
        return false;
    }


    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
    */
}
