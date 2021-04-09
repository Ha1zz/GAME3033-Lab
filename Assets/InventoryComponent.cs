using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Character;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] private List<ItemScriptables> Items = new List<ItemScriptables>();

    private PlayerController Controller;

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
    }

    public List<ItemScriptables> GetItemList() => Items;
    public int GetItemCount() => Items.Count;

    public ItemScriptables FindItem(string itemName)
    {
        return Items.Find((invItem) => invItem.Name == itemName);
    }

    public void AddItem(ItemScriptables item, int amount = 0)
    {
        int itemIndex = Items.FindIndex(itemScipt => itemScipt.Name == item.Name);
        if (itemIndex != -1)
        {
            ItemScriptables listItem = Items[itemIndex];
            if (item.Stackable && listItem.Amount < listItem.MaxStack)
            {
                listItem.ChangeAmount(item.Amount);
            }
        }
        else
        {
            if (item == null) return;

            ItemScriptables itemClone = Instantiate(item);
            itemClone.Initialize(Controller);
            itemClone.SetAmount(amount <= 1 ? item.Amount : amount);
            Items.Add(itemClone);
        }
    }

    public void DeleteItem(ItemScriptables item)
    {
        int itemIndex = Items.FindIndex(listItem => listItem.Name == item.Name);
        if (itemIndex == -1) return;

        Items.Remove(item);
    }

    public List<ItemScriptables> GetItemsOfCategory(ItemCategory itemCategory)
    {
        if (Items == null || Items.Count <= 0) return null;
        return (itemCategory == ItemCategory.None) ? 
            Items : Items.FindAll(item => item.ItemCategory == itemCategory);
    }

}

public enum ItemCategory
{
    None,
    Weapon,
    Equipment,
    Consumable,
    Ammo,
}
