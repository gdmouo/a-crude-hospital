using Unity.VisualScripting;
using UnityEngine;

public class BeatSceneInputMap : InputMap
{
    [SerializeField] private bool keepMouseEnabled = true;
    [SerializeField] private SongStageRunner stageRunner;
    public override InputMapType GetInputMapType()
    {
        return InputMapType.BeatScene;
    }

    protected override void OnEnableMap(PlayerInputActions p)
    {
        p.BeatScene.Enable();
        p.BeatScene.Play.performed += Play_performed;
        
        if (inputMapManager != null)
        {
            if (keepMouseEnabled) return;
            inputMapManager.Mouse.ToggleCursor(CursorLockMode.Locked);
        }
    }

    private void Play_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        stageRunner.Play();
    }

    protected override void OnDisableMap(PlayerInputActions p)
    {
        p.BeatScene.Play.performed -= Play_performed;
        p.BeatScene.Disable();
    }
}
