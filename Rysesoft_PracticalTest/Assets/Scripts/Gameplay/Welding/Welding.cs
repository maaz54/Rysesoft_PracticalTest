using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class Welding : MonoBehaviour
    {
        [Header("Welding Settings")]
        public float weldDuration = 2f;
        public GameObject sparksFX;
        public AudioSource weldSound;
        public CraftingManager craftingManager;
        public int itemIndex; // Which item this plane belongs to

        private bool isWelding = false;
        private bool isCompleted = false;

        public void StartWelding()
        {
            if (isWelding || isCompleted) return;

            isWelding = true;
            StartCoroutine(WeldRoutine());
        }

        private IEnumerator WeldRoutine()
        {
            // Turn on FX
            if (sparksFX != null) sparksFX.SetActive(true);
            if (weldSound != null) weldSound.Play();

            yield return new WaitForSeconds(weldDuration);

            // Turn off FX
            if (sparksFX != null) sparksFX.SetActive(false);
            if (weldSound != null) weldSound.Stop();

            isCompleted = true;

            // Tell crafting manager welding is done
            // if (craftingManager != null)
            // craftingManager.SpawnFinalItem(itemIndex);

            // Remove weld plane
            Destroy(gameObject);
        }
    }
}
