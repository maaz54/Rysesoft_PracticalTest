using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CraftableItem", menuName = "Crafting/Craftable Item")]
public class CraftableItem : Item
{
    public GameObject weldShapePrefab;
    public Item ItemToCraft;
}
