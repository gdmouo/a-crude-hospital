using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    public CharacterType GetCharacterType();
}

[System.Serializable]
public enum CharacterType { 
    Player,
    NPC
}


