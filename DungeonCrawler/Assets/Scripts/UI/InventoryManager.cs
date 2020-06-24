using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : UIManager
{

    public Transform itemsParent;
    [SerializeField] Inventory inventory;

    [SerializeField]InventorySlot[] slots;

    private void Awake()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        foreach (InventorySlot item in slots)
        {
            item.inventory = inventory;
        }
        Debug.Log(slots.Length);
    }

    public void UpdateInventoryUI()
    {

        Debug.Log("IUI");
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.itemList.Count)
            {
                slots[i].AddItem(inventory.itemList[i]);
                Debug.Log("SlotAdded");
            }
            else
            {
                Debug.Log("SlotCleared");
                slots[i].ClearSlot();
            }
        }
    }


}
