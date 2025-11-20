using System.Collections;
using System.Collections.Generic;
using Gameplay.UI;
using UnityEngine;

namespace Gameplay
{
    public class CraftingManager : MonoBehaviour
    {
        [SerializeField] CraftingManagerUI craftingManagerUI;
        [SerializeField] CraftableItem[] craftableItems;

        void Start()
        {
            PopulateUi();
        }

        private void PopulateUi()
        {
            if (craftingManagerUI != null)
                craftingManagerUI.InitalizeCraftables(craftableItems);
        }
    }
}
