using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private CursorController cursorController;

    public void ToggleCursor(CursorLockMode mode)
    {
        if (cursorController == null)
        {
            cursorController = new CursorController();
        }
        if (mode == CursorLockMode.Locked)
        {
            cursorController.LockCursor();
        } else if (mode == CursorLockMode.None)
        {
            cursorController.UnlockCursor();
        }
    }
}
