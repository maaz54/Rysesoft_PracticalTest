using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CraftableItem", menuName = "Crafting/Craftable Item")]
public class CraftableItem : ScriptableObject
{
    public string itemName;
    public GameObject finalPrefab;
    public GameObject weldShapePrefab;
}
