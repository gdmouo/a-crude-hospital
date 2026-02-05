using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    public CharacterType GetCharacterType();
  //  public void CharacterTriggerFunction(Collider collider);
}

[System.Serializable]
public enum CharacterType { 
    Player,
    NPC,
    Maeby
}


