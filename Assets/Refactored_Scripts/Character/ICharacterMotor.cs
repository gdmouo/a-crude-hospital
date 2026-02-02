using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public interface ICharacterMotor
{
    public void Init(Character c);
    public void Move();
}
