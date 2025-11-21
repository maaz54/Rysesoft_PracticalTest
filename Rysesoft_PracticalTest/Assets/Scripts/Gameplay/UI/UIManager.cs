using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI
{


    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject InventoryPanel;
        [SerializeField] GameObject CraftingPanel;
        [SerializeField] GameObject hintPanel;
        [SerializeField] Button craftingbutton;
        [SerializeField] Button Inventorybutton;
        [SerializeField] Button hintButton;
        [SerializeField] Canvas canvas;


        void Start()
        {
            craftingbutton.onClick.AddListener(OnCraftingButton);
            Inventorybutton.onClick.AddListener(OnInventoryButton);
            hintButton.onClick.AddListener(ToggleHint);
        }

        /// <summary>
        /// Called when the Crafting button is clicked.
        /// </summary>
        private void OnCraftingButton()
        {
            SwitchPanel(CraftingPanel);
        }

        /// <summary>
        /// Called when the Inventory button is clicked.
        /// </summary>
        private void OnInventoryButton()
        {
            SwitchPanel(InventoryPanel);

        }

        //Deactivates all panels and activates the selected panel
        private void SwitchPanel(GameObject panel)
        {
            InventoryPanel.SetActive(false);
            CraftingPanel.SetActive(false);

            panel.SetActive(true);
        }


        /// <summary>
        /// Toggles the hint panel on/off.
        /// </summary>
        private void ToggleHint()
        {
            hintPanel.SetActive(!hintPanel.activeSelf);
        }


        /// <summary>
        /// Closes all UI by disabling the root canvas.
        /// </summary>
        public void CloseAllwindow()
        {
            canvas.gameObject.SetActive(false);
        }
    }
}