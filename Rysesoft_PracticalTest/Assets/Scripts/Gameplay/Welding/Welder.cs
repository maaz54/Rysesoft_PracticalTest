using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welder : MonoBehaviour
{
    Camera cam;

    private WeldablePart currentPart;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TryWeld();
        }
        else
        {
            if (currentPart != null)
            {
                currentPart.StopWeld();
                currentPart = null;
            }

        }
    }

    private void TryWeld()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 3f))
        {
            WeldablePart wp = hit.collider.GetComponent<WeldablePart>();

            if (wp != null)
            {
                if (currentPart != wp)
                {
                    currentPart?.StopWeld();
                    currentPart = wp;
                }

                currentPart.StartWeld();
            }
        }
    }
}
