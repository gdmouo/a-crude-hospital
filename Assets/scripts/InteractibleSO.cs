using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interactible", menuName = "InteractibleSO")]
public class InteractibleSO : ScriptableObject
{
    public Sprite sprite;
    public Sprite heldSprite;
    public Sprite openedSprite;
    public string itemName;
    public string itemDescription;

}
