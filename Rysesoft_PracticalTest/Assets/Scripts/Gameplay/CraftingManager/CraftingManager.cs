using System.Collections;
using System.Collections.Generic;
using Gameplay.UI;
using Unity.Mathematics;
using UnityEngine;

namespace Gameplay
{
    public class CraftingManager : MonoBehaviour
    {
        [SerializeField] CraftingManagerUI craftingManagerUI;
        [SerializeField] CraftableItem[] craftableItems;
        [SerializeField] CraftingTable craftingTable;

        void Start()
        {
            PopulateUi();

            craftingManagerUI.OnCraftItemSelected += OnCraftItemSelected;
        }

        private void PopulateUi()
        {
            if (craftingManagerUI != null)
                craftingManagerUI.InitalizeCraftables(craftableItems);
        }

        private void OnCraftItemSelected(CraftableItem craftableItem)
        {
            WeldablePart weldablePart =
                 Instantiate(craftableItem.ItemToWeild, 
                            craftingTable.SpawnPoint.transform.position, 
                            craftingTable.SpawnPoint.transform.rotation);

            weldablePart.OnWeldCompleted += OnWeldingComplete;
        }

        private void OnWeldingComplete(WeldablePart weldablePart, CraftableItem craftableItem)
        {
            GameObject gameObject = 
            Instantiate(craftableItem.finalPrefab,
                        craftingTable.SpawnPoint.transform.position,
                        craftingTable.SpawnPoint.transform.rotation);

            Destroy(weldablePart.gameObject);
        }
    }
}
