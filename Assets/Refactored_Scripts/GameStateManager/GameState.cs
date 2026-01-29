using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    protected GameStateSO gameStateSO;
    protected GameStateManager gameStateManager;

    public GameState(GameStateSO g,  GameStateManager s)
    {
        this.gameStateSO = g;
        this.gameStateManager = s;
    }

    /*
     *  public GameStateType gameStateType;
    public GameObject canvasObject;
    public InputMapType inputMapType;
    public bool playerControlsEnabled;
     */

    public GameStateType GetStateLabel() {
        return gameStateSO.gameStateType;
    }

    //UPDATE STATE WITHIN HERE
    public void ActivateState()
    {
        OnActivate();
        //activate canvas state
        //activate input map state
        gameStateManager.UpdateCurrState(this);
    }
    public void DeactivateState()
    {
        //updatecurrstate
        //deactivate input map state
        //deactivate canvas state
        OnDeactivate();
    }

    public abstract void OnActivate();
    public abstract void OnDeactivate();
}

public class MenuState : GameState {
    private GameState prevState;

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
    public MenuState(GameStateSO g, GameStateManager s) : base(g, s)
    {
        prevState = gameStateManager.GetCurrState();
    }
    public override void OnActivate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnDeactivate()
    {
        throw new System.NotImplementedException();
    }
}
public class InventoryState : GameState
{
    //state specific measures
    /*
     * if (activate) 
     *  if (currstate == hud)
     *      disable previous state
     *      enable
     *  else return
     * else 
     * disable state
     * activate hud state
     */
    public InventoryState(GameStateSO g, GameStateManager s) : base(g, s)
    {
    }
    public override void OnActivate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnDeactivate()
    {
        throw new System.NotImplementedException();
    }
}

public class DialogueState : GameState
{
    //state specific measures
    /*
     * if (activate) 
     *  if (currstate == hud)
     *      disable previous state
     *      enable
     *  else return
     * else 
     * disable state
     * activate hud state
     */
    public DialogueState(GameStateSO g, GameStateManager s) : base(g, s)
    {
    }
    public override void OnActivate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnDeactivate()
    {
        throw new System.NotImplementedException();
    }
}

public class HUDState : GameState
{
    //state specific measures
    /*
     * if (activate) 
     *  enable
     * else 
     * disable state
     * activate hud state
     */
    public HUDState(GameStateSO g, GameStateManager s) : base(g, s)
    {
    }
    public override void OnActivate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnDeactivate()
    {
        throw new System.NotImplementedException();
    }
}