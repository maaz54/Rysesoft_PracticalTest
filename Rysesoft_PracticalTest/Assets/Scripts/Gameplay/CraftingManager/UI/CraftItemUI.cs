using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.UI
{
    public class CraftItemUI : MonoBehaviour
    {
        [SerializeField] CraftableItem craftableItem;

        public void Initialize(CraftableItem craftableItem)
        {
            this.craftableItem = craftableItem;
        }
    }
}
