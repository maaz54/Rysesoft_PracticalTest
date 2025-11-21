using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] InventoryManagerUI inventoryUI;
        [SerializeField] List<Item> storageInventory = new List<Item>();

        [Header("Stack Settings")]
        [SerializeField] Transform stackPoint;      // where the first item appears
        [SerializeField] Vector3 stackOffset = new Vector3(0, 0.2f, 0);

        public void AddToStorage(Item item)
        {
            storageInventory.Add(item);
            inventoryUI.AddItem(item);


            Vector3 newPos = stackPoint.position + (stackOffset * (storageInventory.Count - 1));
            item.transform.position = newPos;

            // Optional: reset rotation to stack neatly
            item.transform.rotation = stackPoint.rotation;
        }
    }

}