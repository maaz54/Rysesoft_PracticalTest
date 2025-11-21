using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


namespace Inventory
{

    public class InventoryItemUi : MonoBehaviour
    {
        [SerializeField] Item craftableItem;
        [SerializeField] TextMeshProUGUI itemName;
        [SerializeField] Button button;


        /// <summary> 
        /// Event fired when the player selects this item. 
        /// Subscribers receive the Item instance. 
        /// </summary>
        public Action<Item> OnItemSelected;

        /// <summary> 
        /// Initializes the UI element with an item.
        ///  </summary>
        public void Initialize(Item item)
        {
            this.craftableItem = item;
            itemName.text = item.ItemName;
            button.onClick.AddListener(OnSelected);
        }

        /// <summary>
        /// Called when the player clicks the button.
        /// </summary>
        public void OnSelected()
        {
            OnItemSelected?.Invoke(craftableItem);
        }
    }
}