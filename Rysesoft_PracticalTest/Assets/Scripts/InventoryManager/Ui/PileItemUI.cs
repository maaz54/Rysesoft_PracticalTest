using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PileItemUI : MonoBehaviour
{
    [SerializeField] Item craftableItem;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] Button button;
    public Action<Item> OnItemSelected;

    public void Initialize(Item item)
    {
        this.craftableItem = item;
        itemName.text = item.ItemName;
        button.onClick.AddListener(OnSelected);
    }

    public void OnSelected()
    {
        OnItemSelected?.Invoke(craftableItem);
    }
}
