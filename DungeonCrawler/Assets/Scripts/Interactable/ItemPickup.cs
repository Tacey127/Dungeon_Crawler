using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    PlayerInteraction interaction;
    public override void Interact(PlayerInteraction interact)
    {
        interaction = interact;
        PickUp();
    }

    void PickUp()
    {
        if (interaction.inventory.AddItem(item)) 
        {
            Destroy(gameObject);
        }


    }
}
