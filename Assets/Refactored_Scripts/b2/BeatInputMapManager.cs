using UnityEngine;

public class BeatInputMapManager : InputMapManager
{
    [SerializeField] private InputMap beatInputMap;
    protected override void OnStart()
    {
        if (!beatInputMap.MapEnabled)
        {
            beatInputMap.EnableMap(playerInputActions);
        }
    }
}
