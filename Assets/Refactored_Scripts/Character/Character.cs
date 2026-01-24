using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, ICharacter
{
    public abstract CharacterType GetCharacterType();
    public abstract void CharacterTriggerFunction(Collider other);

    private void OnTriggerEnter(Collider other)
    {
        CharacterTriggerFunction(other);
    }
}
