using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject InventoryPanel;
    [SerializeField] GameObject CraftingPanel;
    [SerializeField] Button craftingbutton;
    [SerializeField] Button Inventorybutton;
    [SerializeField] Canvas canvas;


    void Start()
    {
        craftingbutton.onClick.AddListener(OnCraftingButton);
        Inventorybutton.onClick.AddListener(OnInventoryButton);
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

    public void CloseAllwindow()
    {
        canvas.gameObject.SetActive(false);
    }
}
