using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.UI;
using UnityEngine;

public class PileUIManager : MonoBehaviour
{
    public Action<Item> OnCraftItemSelected;

    [SerializeField] Transform craftableItemHolder;
    [SerializeField] PileItemUI craftableItemPrefab;
    [SerializeField] List<PileItemUI> craftableUiItems;
    [SerializeField] List<Item> craftableItems;

    public void AddItem(Item item)
    {
        PileItemUI pileItem = Instantiate(craftableItemPrefab, craftableItemHolder);
        pileItem.Initialize(item);
        craftableUiItems.Add(pileItem);
        pileItem.OnItemSelected += OnItemSelected;
    }

    private void OnItemSelected(Item craftableItem)
    {
        OnCraftItemSelected?.Invoke(craftableItem);
    }
}
