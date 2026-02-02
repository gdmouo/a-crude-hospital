using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState : MonoBehaviour
{
    [SerializeField] protected GameStateType gameStateType;
    public GameStateType StateType { get { return gameStateType; } }
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


    public void ActivateState()
    {
        OnActivate();
    }
    public void DeactivateState()
    {
        OnDeactivate();
    }

    //public abstract GameS
    protected abstract void OnActivate();
    protected abstract void OnDeactivate();
}