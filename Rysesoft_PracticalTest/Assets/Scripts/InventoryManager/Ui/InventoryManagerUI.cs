using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{

    public class InventoryManagerUI : MonoBehaviour
    {
        public Action<Item> OnCraftItemSelected;
        [SerializeField] Transform itemHolder;
        [SerializeField] InventoryItemUi itemPrefab;
        [SerializeField] List<InventoryItemUi> uiItems;
        [SerializeField] List<Item> items;

        /// <summary>
        /// Adds an item to the inventory UI.
        /// </summary>
        public void AddItem(Item item)
        {
            InventoryItemUi inventoryItemUi = Instantiate(itemPrefab, itemHolder);
            inventoryItemUi.Initialize(item);
            uiItems.Add(inventoryItemUi);
            inventoryItemUi.OnItemSelected += OnItemSelected;
        }

        /// <summary>
        /// Internal handler when a UI item is selected.
        /// Fires the public OnItemSelected event.
        /// </summary>
        private void OnItemSelected(Item item)
        {
            OnCraftItemSelected?.Invoke(item);

        }
    }
}