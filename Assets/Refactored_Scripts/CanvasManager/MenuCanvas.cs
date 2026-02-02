using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : StateCanvas
{
    public override StateCanvasType GetStateCanvasType()
    {
        return StateCanvasType.Menu;
    }

    //button functions V

    public void OnClickResume()
    {
        GameStateManager g = GameStateManager.Instance;

        if (g != null)
        {
            g.ToggleState(GameStateType.Menu);
        }
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
