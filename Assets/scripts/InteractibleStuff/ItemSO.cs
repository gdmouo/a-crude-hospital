using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ItemSO")]
public class ItemSO : InteractibleSO
{
    public Sprite sprite;
    public Sprite heldSprite;
    public string itemDescription;
}
