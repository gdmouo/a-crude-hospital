using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatPadController : MonoBehaviour
{
    [SerializeField] private List<BeatPad> beatPads;
    private Dictionary<KeyControlling, BeatPad> keyBeatPads;
    private BeatRoomInput beatRoomInput;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        if (beatPads == null)
        {
            Debug.Log("Critical variable unassigned in: " + gameObject.name);
            return;
        }
        keyBeatPads = GetBeatDictionary(beatPads);
        InputMapManager i = InputMapManager.Instance;
        if (i == null)
        {
            Debug.Log("Critical variable unassigned in: " + gameObject.name);
            return;
        }
        InputMap iM = i.GetMapByType(InputMapType.BeatRoom);
        beatRoomInput = iM as BeatRoomInput;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        HandleInputKeys();
    }

    public void SelectBeatPad(KeyControlling k)
    {
        if (keyBeatPads == null)
        {
            return;
        }
        BeatPad selectedBeatPad = null;

        if (keyBeatPads.TryGetValue(k, out BeatPad bP))
        {
            selectedBeatPad = bP;
        }

        if (selectedBeatPad != null)
        {
            selectedBeatPad.Input();
        }
    }

    public Dictionary<KeyControlling, BeatPad> GetBeatDictionary(List<BeatPad> l)
    {
        if (l == null)
        {
            return null;
        }
        Dictionary<KeyControlling, BeatPad> temp = new Dictionary<KeyControlling, BeatPad>();
        foreach (BeatPad b in l)
        {
            keyBeatPads.Add(b.KeyButton, b);
        }
        return temp;
    }

    private void HandleInputKeys()
    {
        if (beatRoomInput == null)
        {
            return;
        }

        if (beatRoomInput.IsWPressed())
        {
            SelectBeatPad(KeyControlling.W_KEY);
        }
        if (beatRoomInput.IsAPressed())
        {
            SelectBeatPad(KeyControlling.A_KEY);
        }
        if (beatRoomInput.IsSPressed())
        {
            SelectBeatPad(KeyControlling.S_KEY);
        }
        if (beatRoomInput.IsDPressed())
        {
            SelectBeatPad(KeyControlling.D_KEY);
        }

        if (beatRoomInput.IsUpPressed())
        {
            SelectBeatPad(KeyControlling.UP_ARR);
        }
        if (beatRoomInput.IsDownPressed())
        {
            SelectBeatPad(KeyControlling.DOWN_ARR);
        }
        if (beatRoomInput.IsLeftPressed())
        {
            SelectBeatPad(KeyControlling.LEFT_ARR);
        }
        if (beatRoomInput.IsRightPressed())
        {
            SelectBeatPad(KeyControlling.RIGHT_ARR);
        }
    }

}
