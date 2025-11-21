using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagerUI : MonoBehaviour
{
    public Action<Item> OnCraftItemSelected;
    [SerializeField] Transform itemHolder;
    [SerializeField] InventoryItemUi itemPrefab;
    [SerializeField] List<InventoryItemUi> uiItems;
    [SerializeField] List<Item> items;

    public void AddItem(Item item)
    {
        InventoryItemUi inventoryItemUi = Instantiate(itemPrefab, itemHolder);
        inventoryItemUi.Initialize(item);
        uiItems.Add(inventoryItemUi);
        inventoryItemUi.OnItemSelected += OnItemSelected;
    }

    private void OnItemSelected(Item craftableItem)
    {
        OnCraftItemSelected?.Invoke(craftableItem);
        
    }
}
