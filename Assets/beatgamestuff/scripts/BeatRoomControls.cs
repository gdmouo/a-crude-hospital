using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatRoomControls : MonoBehaviour
{
    public static BeatRoomControls Instance { get; private set; }

    private PlayerInputActions playerInputActions;

    private Pussyvagin bpCont;


    private void Awake()
    {
        if (Instance != null)
        {
            //Destroy(gameObject);
           // return;
        }
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        bpCont = Pussyvagin.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        HandleArrowKeys();
    }

    private void HandleArrowKeys()
    {
        HandleArrowOnBeatPadCont(playerInputActions.Player.Move.ReadValue<Vector2>());
    }

    private void HandleArrowOnBeatPadCont(Vector2 v)
    {

        if (v.x < 0f)
        {
            bpCont.HitBar(Dir.lurft);
        } else if (v.x > 0f)
        {
            bpCont.HitBar(Dir.rut);
        } 

        if (v.y < 0f)
        {
            bpCont.HitBar(Dir.durn);
        }
        else if (v.y > 0f)
        {
            bpCont.HitBar(Dir.urp);
        }
    }

    //
}
