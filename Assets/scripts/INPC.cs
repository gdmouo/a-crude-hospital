using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPC
{

    // [SerializeField] private NPCMotor npcMotor;
    // public bool Activated { get; private set; }

    public void Activate();
    public void SetDest(Vector3 l);
    public void StartPath();

    public void TogglePausePath(bool b);

    public void MovePos(Vector3 p);
    //maybe in eed to clear target before the next one.. not sure

    public void Deactivate();

}
