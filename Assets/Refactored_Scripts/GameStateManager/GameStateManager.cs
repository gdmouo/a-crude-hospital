using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private GameState currentGameState;
    //private 
    
    public static GameStateManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    public void ToggleState(GameStateType gameStateType)
    {
        GameStateType currState = currentGameState.GetStateLabel();
        bool activate = currState == gameStateType;

        //state specific measures
        //check if activate or not
        //handle canvas
        //enable map
        //enable/disable player input

        switch (currState)
        {
            case GameStateType.Menu:
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
                break;
            case GameStateType.Inventory:
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

                break;
            case GameStateType.Dialogue:
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
                break;
            case GameStateType.HUD:
            //state specific measures
            /*
             * if (activate) 
             *  enable
             * else 
             * disable state
             * activate hud state
             */
            default:
                break;
        }
    }

    public void UpdateCurrState(GameState gameState)
    {
        currentGameState = gameState;
    }

    public GameState GetCurrState()
    {
        return currentGameState;
    }



}


public enum GameStateType { 
    Menu,
    Inventory,
    Dialogue,
    HUD //identifier, crosshair, hotbar, objectives
}
