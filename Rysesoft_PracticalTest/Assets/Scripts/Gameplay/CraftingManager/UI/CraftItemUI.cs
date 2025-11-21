using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Inventory;

namespace Gameplay.UI
{
    /// <summary>
    /// UI element that represents a single craftable item in the crafting menu.
    /// Displays the item name and triggers an event when clicked.
    /// </summary>
    public class CraftItemUI : MonoBehaviour
    {
        [SerializeField] CraftableItem craftableItem;
        [SerializeField] TextMeshProUGUI itemName;
        [SerializeField] Button button;

        /// <summary>
        /// Event fired when this item is clicked.
        /// Passes the CraftableItem back to the CraftingManagerUI.
        /// </summary>
        public Action<CraftableItem> OnItemSelected;

        /// <summary>
        /// Initializes this UI element with data from a CraftableItem.
        /// Sets name text and binds the button click event.
        /// </summary>
        public void Initialize(CraftableItem craftableItem)
        {
            this.craftableItem = craftableItem;
            itemName.text = craftableItem.itemName;
            button.onClick.AddListener(OnSelected);
        }

        /// <summary>
        /// Called when the UI button is clicked.
        /// Invokes the selection event to notify listeners.
        /// </summary>
        public void OnSelected()
        {
            OnItemSelected?.Invoke(craftableItem);
        }
    }
}
