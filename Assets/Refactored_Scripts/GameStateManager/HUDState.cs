using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

public class HUDState : GameState
{
    protected override void OnActivate()
    {
        StateManager g = StateManager.Instance;
        StateCanvasManager s = StateCanvasManager.Instance;
        InputMapManager i = InputMapManager.Instance;

        List<GameStateType> statesToActivate = new List<GameStateType>();
        List<GameStateType> statesToDeactivate = new List<GameStateType>();

        if (i == null || s == null || g == null)
        {
            return;
        }

        GameState currState = g.GetCurrentState();

        if (currState != null && currState != this)
        {
            statesToDeactivate.Add(currState.StateType);
        }

        statesToActivate.Add(gameStateType);

        s.ToggleCanvases(statesToActivate, statesToDeactivate);
        i.ToggleMaps(statesToActivate, statesToDeactivate);

        g.UpdateCurrState(this);
    }

    //dont think this should be called naywaysvv

    protected override void OnDeactivate()
    {
        StateManager g = StateManager.Instance;
        StateCanvasManager s = StateCanvasManager.Instance;
        InputMapManager i = InputMapManager.Instance;

        if (i == null || s == null || g == null)
        {
            return;
        }

        List<GameStateType> statesToDeactivate = new List<GameStateType>();

        statesToDeactivate.Add(gameStateType);

        s.ToggleCanvases(null, statesToDeactivate);
        i.ToggleMaps(null, statesToDeactivate);

        g.UpdateCurrState(null);
    }
}
