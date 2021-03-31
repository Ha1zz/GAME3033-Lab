using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] private List<ItemScriptables> Items = new List<ItemScriptables>();


}

public enum ItemCategory
{
    None,
    Weapon,
    Equipment,
    Consumable,
    Ammo,
}