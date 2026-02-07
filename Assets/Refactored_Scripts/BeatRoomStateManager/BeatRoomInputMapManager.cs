using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatRoomInputMapManager : InputMapManager
{
    protected InputMap beatControls;
    protected override void OnStart()
    {
        if (beatControls == null)
        {
            beatControls = GetMapByType(InputMapType.BeatRoom);
            if (!beatControls.MapEnabled)
            {
                beatControls.EnableMap(playerInputActions);
            }
        }
    }
}
