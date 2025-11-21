using System.Collections;
using System.Collections.Generic;
using Gameplay.UI;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Inventory;

namespace Gameplay
{
    /// <summary>
    /// 
    /// </summary>
    public class CraftingManager : MonoBehaviour
    {
        UIManager uIManager;
        PileManager pileManager;
        CraftingManagerUI craftingManagerUI;
        [SerializeField] CraftableItem[] craftableItems;
        CraftingTable craftingTable;

        /// <summary>
        /// Zenject constructor used to inject required managers at runtime
        /// </summary>
        [Inject]
        public void Construct(PileManager pileManager, UIManager uIManager, CraftingManagerUI craftingManagerUI, CraftingTable craftingTable)
        {
            this.pileManager = pileManager;
            this.uIManager = uIManager;
            this.craftingManagerUI = craftingManagerUI;
            this.craftingTable = craftingTable;
        }


        void Start()
        {
            PopulateUi();

            // craftingManagerUI.OnCraftItemSelected += OnCraftItemSelected;
            craftingManagerUI.OnCraftItemSelected += SpawnPartsInGrid;
        }

        /// <summary>
        /// Sends all craftable items to UI so player can see and select them.
        /// </summary>
        private void PopulateUi()
        {
            if (craftingManagerUI != null)
                craftingManagerUI.InitalizeCraftables(craftableItems);
        }


        private List<WeldablePart> activeParts = new List<WeldablePart>();
        private int completedCount = 0;

        private void OnCraftItemSelected(CraftableItem craftableItem)
        {
            completedCount = 0;
            activeParts.Clear();

            foreach (var part in craftableItem.ItemToWeild)
            {
                WeldablePart spawned =
                    Instantiate(part,
                        craftingTable.SpawnPoint.position,
                        part.transform.rotation);

                spawned.OnWeldCompleted += OnPartWeldCompleted;
                activeParts.Add(spawned);
            }

            uIManager.CloseAllwindow();

        }

        /// <summary>
        /// Spawns multiple weldable parts arranged in a grid so they are not stacked on each other.
        /// This is used for items that require welding 3–5 separate parts.
        /// </summary>
        private void SpawnPartsInGrid(CraftableItem craftableItem)
        {
            craftingManagerUI.OnCraftItemSelected -= SpawnPartsInGrid;
            completedCount = 0;
            activeParts.Clear();

            int count = craftableItem.ItemToWeild.Length;

            int columns = 3;      // how many per row
            float spacing = .25f;   // distance between items

            for (int i = 0; i < count; i++)
            {
                int row = i / columns;
                int column = i % columns;

                Vector3 offset =
                    new Vector3(column * spacing, 0, row * spacing);

                Vector3 spawnPos =
                    craftingTable.SpawnPoint.position + offset;

                WeldablePart spawned =
                    Instantiate(craftableItem.ItemToWeild[i],
                                spawnPos,
                                craftableItem.ItemToWeild[i].transform.rotation);

                spawned.OnWeldCompleted += OnPartWeldCompleted;
                activeParts.Add(spawned);
            }

            uIManager.CloseAllwindow();
        }

        /// <summary>
        /// Called every time a single weldable part is completed.
        /// </summary>
        private void OnPartWeldCompleted(WeldablePart part, CraftableItem craftableItem)
        {
            completedCount++;
            part.gameObject.SetActive(false);
            if (completedCount >= craftableItem.ItemToWeild.Length)
            {
                FinalizeCraft(craftableItem);
            }
        }

        /// <summary>
        /// Spawns the final crafted item and sends it to the crafting pile.
        /// </summary>
        private void FinalizeCraft(CraftableItem craftableItem)
        {
            // Spawn final crafted item
            Item final =
                Instantiate(craftableItem.finalPrefab,
                    craftingTable.SpawnPoint.position,
                    craftingTable.SpawnPoint.rotation);

            // Add to pile
            pileManager.AddToStorage(final);

            // Destroy parts
            foreach (var part in activeParts)
            {
                Destroy(part.gameObject);
            }

            activeParts.Clear();
            craftingManagerUI.OnCraftItemSelected += SpawnPartsInGrid;
        }

        private void OnWeldingComplete(WeldablePart weldablePart, CraftableItem craftableItem)
        {
            Item item =
            Instantiate(craftableItem.finalPrefab,
                        craftingTable.SpawnPoint.transform.position,
                        craftingTable.SpawnPoint.transform.rotation);

            pileManager.AddToStorage(item);

            Destroy(weldablePart.gameObject);
        }
    }
}
