using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

public class BeatRoomState : GameState
{
    protected override void OnActivate()
    {
        StateManager b = StateManager.Instance;
        InputMapManager bI = InputMapManager.Instance;

        List<GameStateType> statesToActivate = new List<GameStateType>();

        if (bI == null || b == null)
        {
            return;
        }

        statesToActivate.Add(gameStateType);

        bI.ToggleMaps(statesToActivate, null);

        //activate beat room, deactivate none

        b.UpdateCurrState(this);
    }

    protected override void OnDeactivate()
    {
        StateManager b = StateManager.Instance;
        InputMapManager bI = InputMapManager.Instance;

        List<GameStateType> statesToDeactivate = new List<GameStateType>();

        if (bI == null || b == null)
        {
            return;
        }

        statesToDeactivate.Add(gameStateType);

        bI.ToggleMaps(null, statesToDeactivate);

        //activate beat room, deactivate none

        b.UpdateCurrState(null);
    }
}
