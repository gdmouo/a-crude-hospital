using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMouse : MonoBehaviour
{
    public void Toggle(bool value)
    {
        if (value)
        {
            UnlockCursor();
        } else
        {
            LockCursor();
        }

    }
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Optional: Hides the hardware cursor
    }

    // Optional: Call this function to unlock the cursor, for example, when pressing the Escape key
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // Optional: Shows the hardware cursor again
    }
}
