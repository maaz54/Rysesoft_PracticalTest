using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public List<Item> playerInventory = new List<Item>();
        public List<Item> storageInventory = new List<Item>();

        public void AddToPlayerInventory(Item item)
        {
            playerInventory.Add(item);
            item.gameObject.SetActive(false); // Simulate pickup 
            Debug.Log(item.name + " added to Player Inventory");
        }

        public void AddToStorage(Item item)
        {
            storageInventory.Add(item);
            item.gameObject.SetActive(false);
            Debug.Log(item.name + " added to Storage");
        }

    }

}