using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager Instance { get; private set; }
    private CursorController cursorController;

    private void Awake()
    {
        Instance = this;
    }

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
