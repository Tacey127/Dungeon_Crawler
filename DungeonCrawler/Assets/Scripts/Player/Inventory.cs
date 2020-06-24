using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int space = 20;
    public List<Item> itemList;
    [SerializeField] InventoryManager inventoryManager;

    public bool AddItem(Item item) 
    {
        if (!item.isDefaultItem)
        {
            if (itemList.Count >= space)
            {
                return false;
            }
            itemList.Add(item);

            //inventoryui
            inventoryManager.UpdateInventoryUI();

            return true;
        }
        return false;
    }

    public void Remove(Item item)
    {
        itemList.Remove(item);

        //inventoryui
        inventoryManager.UpdateInventoryUI();
    }
}
