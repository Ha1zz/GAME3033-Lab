using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryReferencer : MonoBehaviour
{
    public static InventoryReferencer Instance;

    [SerializeField] private List<ItemScriptables> ItemList = new List<ItemScriptables>();

    private Dictionary<string, ItemScriptables> ItemDictionary = new Dictionary<string, ItemScriptables>();


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        foreach (ItemScriptables itemScriptable in ItemList)
        {
            ItemDictionary.Add(itemScriptable.Name, itemScriptable);
        }
    }

    //private void Start()
    //{
    //    foreach (ItemScriptables itemScriptable in ItemList)
    //    {
    //        ItemDictionary.Add(itemScriptable.Name, itemScriptable);
    //    }
    //}

    public ItemScriptables GetItemReference(string itemName) =>
        ItemDictionary.ContainsKey(itemName) ? ItemDictionary[itemName] : null;

}
