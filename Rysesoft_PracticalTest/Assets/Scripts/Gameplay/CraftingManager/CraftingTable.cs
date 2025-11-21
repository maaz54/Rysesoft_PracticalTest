using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    public Transform SpawnPoint;


    public GameObject craftingUIPanel;
    public GameObject PileUIPanel;
    public GameObject Hint;
    private bool playerInRange = false;

    void Start()
    {
        if (craftingUIPanel != null)
            craftingUIPanel.SetActive(false);

        if (PileUIPanel != null)
            PileUIPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Press E to interact with the table.");
            Hint.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            // close UI when leaving
            if (craftingUIPanel != null)
                craftingUIPanel.SetActive(false);

            if (PileUIPanel != null)
                PileUIPanel.SetActive(false);

            Hint.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (craftingUIPanel != null)
                craftingUIPanel.SetActive(!craftingUIPanel.activeSelf); // toggle UI panel
            Hint.SetActive(!craftingUIPanel.activeSelf); // toggle UI panel
        }
        else if (playerInRange && Input.GetKeyDown(KeyCode.R))
        {
            if (PileUIPanel != null)
                PileUIPanel.SetActive(!PileUIPanel.activeSelf); // toggle UI panel
            Hint.SetActive(!PileUIPanel.activeSelf); // toggle UI panel
        }
    }
}
