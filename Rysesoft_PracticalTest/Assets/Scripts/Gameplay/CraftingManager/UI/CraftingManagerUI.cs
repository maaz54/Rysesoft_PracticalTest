using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.UI
{
    public class CraftingManagerUI : MonoBehaviour
    {
        [SerializeField] Transform craftableItemHolder;
        [SerializeField] CraftItemUI craftableItemPrefab;
        [SerializeField] List<CraftItemUI> craftableUiItems;
        CraftableItem[] craftableItems;

        public void InitalizeCraftables(CraftableItem[] craftableItems)
        {
            this.craftableItems = craftableItems;

            foreach (var item in craftableItems)
            {
                CraftItemUI craftItemUI = Instantiate(craftableItemPrefab, craftableItemHolder);
                craftItemUI.Initialize(item);
                craftableUiItems.Add(craftItemUI);
            }
        }
    }
}
