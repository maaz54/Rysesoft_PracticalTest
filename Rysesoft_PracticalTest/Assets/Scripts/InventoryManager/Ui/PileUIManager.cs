using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.UI;
using UnityEngine;

public class PileUIManager : MonoBehaviour
{
    public Action<Item> OnItemSelect;

    [SerializeField] Transform itemHolder;
    [SerializeField] PileItemUI itemPrefab;
    [SerializeField] List<PileItemUI> uiItems;
    [SerializeField] List<Item> items;

    public void AddItem(Item item)
    {
        PileItemUI pileItem = Instantiate(itemPrefab, itemHolder);
        pileItem.Initialize(item);
        uiItems.Add(pileItem);
        pileItem.OnItemSelected += OnItemSelected;
    }

    private void OnItemSelected(Item craftableItem)
    {
        OnItemSelect?.Invoke(craftableItem);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        uiItems.Remove(uiItems.FirstOrDefault(i => i.Item == item));
    }
}
