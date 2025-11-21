using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void OnCraftingButton()
    {
        SwitchPanel(CraftingPanel);
    }

    private void OnInventoryButton()
    {
        SwitchPanel(InventoryPanel);

    }

    private void SwitchPanel(GameObject panel)
    {
        InventoryPanel.SetActive(false);
        CraftingPanel.SetActive(false);

        panel.SetActive(true);
    }

    private void ToggleHint()
    {
        hintPanel.SetActive(!hintPanel.activeSelf);
    }


    public void CloseAllwindow()
    {
        canvas.gameObject.SetActive(false);
    }
}
