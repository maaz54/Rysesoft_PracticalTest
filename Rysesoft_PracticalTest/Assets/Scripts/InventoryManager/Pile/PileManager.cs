using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;

public class PileManager : MonoBehaviour
{
    [SerializeField] InventoryManager InventoryManager;
    [SerializeField] PileUIManager pileUIManager;
    [SerializeField] List<Item> storageInventory = new List<Item>();

    private void Start()
    {
        pileUIManager.OnItemSelect += MoveItemToInventory;
    }

    public void AddToStorage(Item item)
    {
        storageInventory.Add(item);
        pileUIManager.AddItem(item);
        Debug.Log(item.name + " added to Storage");
    }

    private void MoveItemToInventory(Item item)
    {
        pileUIManager.RemoveItem(item);
        InventoryManager.AddToStorage(item);
    }

}
