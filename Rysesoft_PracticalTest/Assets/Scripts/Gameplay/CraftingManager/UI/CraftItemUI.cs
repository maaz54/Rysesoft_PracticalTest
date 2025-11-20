using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{
    public class CraftItemUI : MonoBehaviour
    {
        [SerializeField] CraftableItem craftableItem;
        [SerializeField] TextMeshProUGUI itemName;
        [SerializeField] Button button;
        public Action<CraftableItem> OnItemSelected;

        public void Initialize(CraftableItem craftableItem)
        {
            this.craftableItem = craftableItem;
            itemName.text = craftableItem.itemName;
            button.onClick.AddListener(OnSelected);
        }

        public void OnSelected()
        {
            OnItemSelected?.Invoke(craftableItem);
        }
    }
}
