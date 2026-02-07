using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatRoomStateManager : StateManager
{
    protected override void OnStart()
    {
        ToggleState(GameStateType.BeatRoom);
    }
}
