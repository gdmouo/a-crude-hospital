using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMovement
{

    public void Move(Vector2 inputVector, Vector3 cameraForward, Vector3 cameraRight, float moveSpeed, float playerRadius, float playerHeight);
    public void Jump(bool value);
}
