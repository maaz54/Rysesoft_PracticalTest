using System;
using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;

namespace Gameplay.UI
{
    /// <summary>
    /// Handles the UI for displaying craftable items and notifying when a craft item is selected.
    /// This class instantiates UI elements for each craftable item and relays selection events.
    /// </summary>
    public class CraftingManagerUI : MonoBehaviour
    {
        /// Event fired when the user selects a craftable item from the UI.
        public Action<CraftableItem> OnCraftItemSelected;

        [SerializeField] Transform craftableItemHolder;
        [SerializeField] CraftItemUI craftableItemPrefab;
        [SerializeField] List<CraftItemUI> craftableUiItems;
        CraftableItem[] craftableItems;

        /// <summary>
        /// Initializes the crafting UI by creating UI elements for each craftable item.
        /// </summary>
        public void InitalizeCraftables(CraftableItem[] craftableItems)
        {
            this.craftableItems = craftableItems;

            foreach (var item in craftableItems)
            {
                CraftItemUI craftItemUI = Instantiate(craftableItemPrefab, craftableItemHolder);
                craftItemUI.Initialize(item);
                craftableUiItems.Add(craftItemUI);
                craftItemUI.OnItemSelected += OnItemSelected;
            }
        }


        /// <summary>
        /// Called when any CraftItemUI triggers its selection event. 
        /// Passes the event upward to listeners (CraftingManager).
        /// </summary>
        private void OnItemSelected(CraftableItem craftableItem)
        {
            OnCraftItemSelected?.Invoke(craftableItem);
        }
    }
}
