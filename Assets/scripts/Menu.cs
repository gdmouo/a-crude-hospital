using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    public bool SwitchedOn { get; private set; }

    [SerializeField] protected GameObject backdrop;

    public bool Toggle()
    {
        if (backdrop.activeSelf)
        {
            backdrop.SetActive(false);
            SwitchedOn = false;
            GameInput.Instance.TogglePlayerControls(false);
            GlobalVariables.Instance.SetGlobalMenuStatus(false);
            return false;
        }
        else
        {
            if (GlobalVariables.Instance.IsMenuOpen())
            {
                return true;
            }
            backdrop.SetActive(true);
            SwitchedOn = true;
            GameInput.Instance.TogglePlayerControls(true);
            GlobalVariables.Instance.SetGlobalMenuStatus(true);
            return true;
        }
    }
}
