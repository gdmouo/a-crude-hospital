using Unity.VisualScripting;
using UnityEngine;

public class BeatSceneInputMap : InputMap
{
    [SerializeField] private bool keepMouseEnabled = true;
    [SerializeField] private SongStageRunner stageRunner;
    [SerializeField] private InputSet inputSet;

    private void Update()
    {
        if (!mapEnabled) return;

        switch (inputSet) {
            case InputSet.WASDARROW:
                HandleWRightPressed();
                break;
            case InputSet.ZXCVNMCommaPeriod:
                HandleZPeriodPressed();
                break;
            case InputSet.ZXCVBNMComma:
                HandleZCommaPressed();
                break;
            case InputSet.ShiftZXCNMCommaPeriod:
                HandleShiftPeriodPressed();
                break;
            case InputSet.ShiftSlash:
                HandleShiftSlashPressed();
                break;
        }

            

    }
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



    private void HandleShiftPeriodPressed()
    {

        if (IsShiftPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.A_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.A_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsZPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.W_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.W_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsXPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.S_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.S_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsCPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.D_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.D_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsNPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.LEFT_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.LEFT_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsMPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.UP_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.UP_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsCommaPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.DOWN_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.DOWN_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsPeriodPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.RIGHT_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.RIGHT_ARR);
            if (p == null) return;
            p.OnReleased();
        }
    }


    private void HandleShiftSlashPressed()
    {

        if (IsShiftPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.A_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.A_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsZPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.W_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.W_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsXPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.S_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.S_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsCPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.D_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.D_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsMPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.LEFT_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.LEFT_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsCommaPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.UP_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.UP_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsPeriodPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.DOWN_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.DOWN_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsSlashPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.RIGHT_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.RIGHT_ARR);
            if (p == null) return;
            p.OnReleased();
        }
    }
    private void HandleZCommaPressed()
    {

        if (IsZPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.A_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.A_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsXPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.W_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.W_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsCPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.S_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.S_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsVPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.D_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.D_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsBPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.LEFT_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.LEFT_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsNPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.UP_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.UP_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsMPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.DOWN_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.DOWN_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsCommaPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.RIGHT_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.RIGHT_ARR);
            if (p == null) return;
            p.OnReleased();
        }
    }

    private void HandleZPeriodPressed()
    {

        if (IsZPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.A_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.A_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsXPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.W_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.W_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsCPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.S_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.S_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsVPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.D_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.D_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsNPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.LEFT_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.LEFT_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsMPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.UP_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.UP_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsCommaPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.DOWN_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.DOWN_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsPeriodPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.RIGHT_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.RIGHT_ARR);
            if (p == null) return;
            p.OnReleased();
        }
    }

    private void HandleWRightPressed()
    {
        if (IsAPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.A_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.A_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsSPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.S_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.S_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsWPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.W_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.W_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsDPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.D_KEY);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.D_KEY);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsLeftPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.LEFT_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.LEFT_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsDownPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.DOWN_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.DOWN_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsUpPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.UP_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.UP_ARR);
            if (p == null) return;
            p.OnReleased();
        }

        if (IsRightPressed())
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.RIGHT_ARR);
            if (p == null) return;
            p.OnHold();
        }
        else
        {
            Pad p = PadManager.Instance.GetPadByLabel(PadLabel.RIGHT_ARR);
            if (p == null) return;
            p.OnReleased();
        }
    }
    private bool IsWPressed()
    {
        return playerInputActions.BeatScene.W.IsPressed();
    }

    private bool IsAPressed()
    {
        return playerInputActions.BeatScene.A.IsPressed();
    }

    private bool IsSPressed()
    {
        return playerInputActions.BeatScene.S.IsPressed();
    }

    private bool IsDPressed()
    {
        return playerInputActions.BeatScene.D.IsPressed();
    }

    private bool IsUpPressed()
    {
        return playerInputActions.BeatScene.Up.IsPressed();
    }

    private bool IsDownPressed()
    {
        return playerInputActions.BeatScene.Down.IsPressed();
    }

    private bool IsLeftPressed()
    {
        return playerInputActions.BeatScene.Left.IsPressed();
    }

    private bool IsRightPressed()
    {
        return playerInputActions.BeatScene.Right.IsPressed();
    }


    private bool IsZPressed()
    {
        return playerInputActions.BeatScene.Z.IsPressed();
    }

    private bool IsXPressed()
    {
        return playerInputActions.BeatScene.X.IsPressed();
    }

    private bool IsCPressed()
    {
        return playerInputActions.BeatScene.C.IsPressed();
    }

    private bool IsVPressed()
    {
        return playerInputActions.BeatScene.V.IsPressed();
    }

    private bool IsBPressed()
    {
        return playerInputActions.BeatScene.B.IsPressed();
    }

    private bool IsNPressed()
    {
        return playerInputActions.BeatScene.N.IsPressed();
    }

    private bool IsMPressed()
    {
        return playerInputActions.BeatScene.M.IsPressed();
    }

    private bool IsCommaPressed()
    {
        return playerInputActions.BeatScene.Comma.IsPressed();
    }

    private bool IsPeriodPressed()
    {
        return playerInputActions.BeatScene.Period.IsPressed();
    }

    private bool IsShiftPressed()
    {
        return playerInputActions.BeatScene.Shift.IsPressed();
    }

    private bool IsSlashPressed()
    {
        return playerInputActions.BeatScene.Slash.IsPressed();
    }
}
public enum InputSet
{
    WASDARROW,
    ZXCVBNMComma,
    ZXCVNMCommaPeriod,
    ShiftZXCNMCommaPeriod,
    ShiftSlash
}