using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileManager : MonoBehaviour
{
    public List<Item> playerInventory = new List<Item>();
    public List<Item> storageInventory = new List<Item>();

    public void AddToStorage(Item item)
    {
        storageInventory.Add(item);
        item.gameObject.SetActive(false);
        Debug.Log(item.name + " added to Storage");
    }

}
