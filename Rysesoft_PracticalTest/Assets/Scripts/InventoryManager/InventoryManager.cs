using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public List<GameObject> playerInventory = new List<GameObject>();
        public List<GameObject> storageInventory = new List<GameObject>();

        public void AddToPlayerInventory(GameObject item)
        {
            playerInventory.Add(item);
            item.SetActive(false); // Simulate pickup 
            Debug.Log(item.name + " added to Player Inventory");
        }

        public void AddToStorage(GameObject item)
        {
            storageInventory.Add(item);
            item.SetActive(false);
            Debug.Log(item.name + " added to Storage");
        }

    }

}