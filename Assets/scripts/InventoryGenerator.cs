using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGenerator : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private int slotCount = 30;
    [SerializeField] private Transform hotbarSlotParent;
    [SerializeField] private Transform backpackParent;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Dictionary<int, InvSlot> GenerateInventory()
    {
        /*
        if (!backpackParent.gameObject.activeSelf)
        {
            backpackParent.gameObject.SetActive(true);
        }*/
        Dictionary<int, InvSlot> inventory = new Dictionary<int, InvSlot>();
        for (int i = 0; i < slotCount; i++)
        {
            GameObject g;
            if (i < 3)
            {
                g = Instantiate(slotPrefab, hotbarSlotParent);
            } else
            {
                g = Instantiate(slotPrefab, backpackParent);
            }
            if (g != null)
            {
                inventory.Add(i, g.GetComponent<InvSlot>());
                g.GetComponent<InvSlot>().SetDigit(i);
            }
        }
        /*
        if (backpackParent.gameObject.activeSelf)
        {
            backpackParent.gameObject.SetActive(false);
        }*/
        return inventory;
    }
}
