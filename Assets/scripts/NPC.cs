using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, INPC
{

    public abstract void Activate();
    public abstract void SetDest(Vector3 l);
    public abstract void StartPath();

    public abstract void TogglePausePath(bool b);

    public abstract void MovePos(Vector3 p);
    //maybe in eed to clear target before the next one.. not sure

    public abstract void Deactivate();
}
