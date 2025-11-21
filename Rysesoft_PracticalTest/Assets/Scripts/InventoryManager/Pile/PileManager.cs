using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;
using Zenject;

public class PileManager : MonoBehaviour
{
    InventoryManager InventoryManager;
    PileUIManager pileUIManager;
    [SerializeField] List<Item> storageInventory = new List<Item>();

    [Inject]
    public void Construct(InventoryManager InventoryManager, PileUIManager pileUIManager)
    {
        this.InventoryManager = InventoryManager;
        this.pileUIManager = pileUIManager;
    }

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
