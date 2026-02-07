using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : GameState
{
    // stateCanvas.ActivateCanvas();
    // inputMap.EnableMap();
    //
    //state specific measures
    /*
     * if (activate) 
     * keep track of previous state
     * disable previous state
     * enable
     * else 
     * disable state
     * activate previous state
     */

    private GameState lastState = null;
    protected override void OnActivate()
    {
       // Debug.Log("ahh");
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

        if (currState != null && currState != this) { 
            lastState = currState;
            statesToDeactivate.Add(lastState.StateType);
        }

        statesToActivate.Add(gameStateType);

        s.ToggleCanvases(statesToActivate, statesToDeactivate);
        i.ToggleMaps(statesToActivate, statesToDeactivate);

        g.UpdateCurrState(this);
    }

    protected override void OnDeactivate()
    {
        StateManager g = StateManager.Instance;
        StateCanvasManager s = StateCanvasManager.Instance;
        InputMapManager i = InputMapManager.Instance;

        if (i == null || s == null || g == null)
        {
            return;
        }

        GameState stateToUpdateTo = null;

        if (lastState == null)
        {
            lastState = g.GetHUDState();
        }

        stateToUpdateTo = lastState;
        lastState = null;

        List<GameStateType> statesToActivate = new List<GameStateType>();
        List<GameStateType> statesToDeactivate = new List<GameStateType>();

        statesToActivate.Add(stateToUpdateTo.StateType);
        statesToDeactivate.Add(gameStateType);

        s.ToggleCanvases(statesToActivate, statesToDeactivate);
        i.ToggleMaps(statesToActivate, statesToDeactivate);


        g.UpdateCurrState(stateToUpdateTo);
    }
}
