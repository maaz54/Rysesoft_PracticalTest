using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;
using Zenject;

namespace Inventory
{

    /// <summary>
    /// Manages the storage (pile) of crafted items.
    /// </summary>
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

        /// <summary>
        /// Adds an item to the pile and updates the UI.
        /// </summary>
        public void AddToStorage(Item item)
        {
            storageInventory.Add(item);
            pileUIManager.AddItem(item);
            Debug.Log(item.name + " added to Storage");
        }

        /// <summary>
        /// Moves the selected item from the pile to the player's inventory.
        /// </summary>
        private void MoveItemToInventory(Item item)
        {
            pileUIManager.RemoveItem(item);
            InventoryManager.AddToStorage(item);
        }

    }
}