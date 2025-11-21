using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{

    /// <summary>
    /// Represents a single item in the Pile (storage) UI.
    /// </summary>
    public class PileItemUI : MonoBehaviour
    {
        [SerializeField] Item item;
        [SerializeField] TextMeshProUGUI itemName;
        [SerializeField] Button button;
        public Action<Item> OnItemSelected;

        /// <summary>
        /// Exposes the underlying item.
        ///  </summary>
        public Item Item => item;


        /// <summary>
        /// Initializes the UI element with the given item.
        /// </summary>
        public void Initialize(Item item)
        {
            this.item = item;
            itemName.text = item.ItemName;
            button.onClick.AddListener(OnSelected);
        }


        /// <summary>
        /// Called when the button is clicked.
        /// </summary>
        public void OnSelected()
        {
            OnItemSelected?.Invoke(item);
        }
    }
}