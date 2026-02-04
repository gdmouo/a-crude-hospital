using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    [SerializeField] private DialogueRunner characterRunner;
    public static CharacterManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public DialogueRunner GetRunner()
    {
        return characterRunner;
    }

    //startyidalgoe

    //enable state 
}
