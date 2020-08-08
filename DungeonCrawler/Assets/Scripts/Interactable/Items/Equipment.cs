using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentType equipType;

    public int armourModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        //equip object
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }

}
public enum EquipmentType { Head, Chest, Legs, Feet }