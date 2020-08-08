using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int space = 20;
    public List<Item> itemList;
    [SerializeField] InventoryUIManager inventoryManager;

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion Singleton

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

    //Accessing inventorys such as chests, dead bodies, etc
    public void SendItemToInventory(Item item, Inventory inventory)
    {
        if(inventory.AddItem(item)){
            Remove(item);
        }
    }

}
