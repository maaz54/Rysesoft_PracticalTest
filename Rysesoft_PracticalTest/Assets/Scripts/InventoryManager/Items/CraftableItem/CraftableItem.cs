using System.Collections;
using System.Collections.Generic;
using Gameplay;
using UnityEngine;

namespace Inventory
{

    [CreateAssetMenu(fileName = "CraftableItem", menuName = "Crafting/Craftable Item")]
    public class CraftableItem : ScriptableObject
    {
        public string itemName;
        public Item finalPrefab;
        public WeldablePart[] ItemToWeild;
    }
}