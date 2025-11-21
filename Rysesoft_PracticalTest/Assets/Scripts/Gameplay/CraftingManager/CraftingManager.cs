using System.Collections;
using System.Collections.Generic;
using Gameplay.UI;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CraftingManager : MonoBehaviour
    {
        UIManager uIManager;
        PileManager pileManager;
        CraftingManagerUI craftingManagerUI;
        [SerializeField] CraftableItem[] craftableItems;
        CraftingTable craftingTable;

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

        private void OnPartWeldCompleted(WeldablePart part, CraftableItem craftableItem)
        {
            completedCount++;
            part.gameObject.SetActive(false);
            if (completedCount >= craftableItem.ItemToWeild.Length)
            {
                FinalizeCraft(craftableItem);
            }
        }

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
