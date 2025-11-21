using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.UI;
using UnityEngine;

namespace Inventory
{

    public class PileUIManager : MonoBehaviour
    {
        public Action<Item> OnItemSelect;

        [SerializeField] Transform itemHolder;
        [SerializeField] PileItemUI itemPrefab;
        [SerializeField] List<PileItemUI> uiItems;
        [SerializeField] List<Item> items;


        /// <summary>
        /// Adds an item to the pile UI.
        /// </summary>
        public void AddItem(Item item)
        {
            PileItemUI pileItem = Instantiate(itemPrefab, itemHolder);
            pileItem.Initialize(item);
            uiItems.Add(pileItem);
            pileItem.OnItemSelected += OnItemSelected;
        }

        /// <summary>
        /// Called when a PileItemUI is clicked.
        /// </summary>
        private void OnItemSelected(Item craftableItem)
        {
            OnItemSelect?.Invoke(craftableItem);
        }


        /// <summary>
        /// Removes an item from the pile and destroys its UI element.
        /// </summary>
        public void RemoveItem(Item item)
        {
            items.Remove(item);
            PileItemUI itemUi = uiItems.FirstOrDefault(i => i.Item == item);
            uiItems.Remove(itemUi);
            Destroy(itemUi.gameObject);
        }
    }
}