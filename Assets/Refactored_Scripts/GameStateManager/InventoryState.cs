using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditorInternal.VersionControl.ListControl;

public class InventoryState : GameState
{
    // stateCanvas.ActivateCanvas();
    // inputMap.EnableMap();
    //
    //state specific measures
    /*
     * if (activate) 
     * disable previous state
     * enable
     * else 
     * disable state
     * activate HUD
     */
    protected override void OnActivate()
    {
        GameStateManager g = GameStateManager.Instance;
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
            if (currState.StateType != GameStateType.HUD)
            {
                return;
            }
        }

        if (currState != null && currState != this)
        {
            statesToDeactivate.Add(currState.StateType);
        }

        statesToActivate.Add(gameStateType);

        s.ToggleCanvases(statesToActivate, statesToDeactivate);
        i.ToggleMaps(statesToActivate, statesToDeactivate);

        g.UpdateCurrState(this);
    }

    protected override void OnDeactivate()
    {
        GameStateManager g = GameStateManager.Instance;
        StateCanvasManager s = StateCanvasManager.Instance;
        InputMapManager i = InputMapManager.Instance;

        if (i == null || s == null || g == null)
        {
            return;
        }

        GameState stateToUpdateTo = g.GetHUDState();

        List<GameStateType> statesToActivate = new List<GameStateType>();
        List<GameStateType> statesToDeactivate = new List<GameStateType>();

        statesToActivate.Add(stateToUpdateTo.StateType);
        statesToDeactivate.Add(gameStateType);

        s.ToggleCanvases(statesToActivate, statesToDeactivate);
        i.ToggleMaps(statesToActivate, statesToDeactivate);


        g.UpdateCurrState(stateToUpdateTo);
    }
}
