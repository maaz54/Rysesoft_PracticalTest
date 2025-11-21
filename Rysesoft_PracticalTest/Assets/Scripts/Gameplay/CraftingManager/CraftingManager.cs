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
            uIManager.CloseAllwindow();

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
