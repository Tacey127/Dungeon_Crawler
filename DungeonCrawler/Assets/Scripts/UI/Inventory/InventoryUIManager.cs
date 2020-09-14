using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the UI interface of a item collection
/// </summary>
public class InventoryUIManager : UIScreen
{

    InventoryUIManager()
    {
        uiShown = UIShown.Inventory;
        cursorMode = CursorLockMode.Confined;
        stopTimeOnScreen = true;
    }


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
    }

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.itemList.Count)
            {
                slots[i].AddItem(inventory.itemList[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }


}
