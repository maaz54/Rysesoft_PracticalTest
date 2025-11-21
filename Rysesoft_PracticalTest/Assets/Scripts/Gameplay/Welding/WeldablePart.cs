using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeldablePart : MonoBehaviour
{
    [SerializeField] CraftableItem ItemToCraft;

    [Header("Welding Settings")]
    [SerializeField] private float weldTimeRequired = 2f;

    [Header("Debug Info")]
    [SerializeField] private float currentProgress;

    public Transform effectAnchor;
    public ParticleSystem weldEffectLoop;
    public ParticleSystem completeEffect;

    public bool IsBeingWelded { get; private set; }
    public bool IsCompleted { get; private set; }

    // Fired when welding completes
    public event Action<WeldablePart, CraftableItem> OnWeldCompleted;
    // Fired when progress updates
    public event Action<float> OnProgressChanged;

    private Vector3 currentWeldPoint;

    private void Update()
    {
        if (IsCompleted)
            return;

        if (IsBeingWelded)
        {
            currentProgress += Time.deltaTime;
            OnProgressChanged?.Invoke(currentProgress / weldTimeRequired);

            if (currentProgress >= weldTimeRequired)
            {
                CompleteWeld();
            }
        }
    }

    public void StartWeld(Vector3 weldPoint)
    {
        if (IsCompleted)
            return;

        currentWeldPoint = weldPoint;

        IsBeingWelded = true;


        if (weldEffectLoop != null && !weldEffectLoop.isPlaying)
        {
            weldEffectLoop.Play();
        }
        weldEffectLoop.transform.position = weldPoint;
    }

    public void StopWeld()
    {
        IsBeingWelded = false;

        if (weldEffectLoop != null && weldEffectLoop.isPlaying)
            weldEffectLoop.Stop();

        // Final burst effect
        if (completeEffect != null)
            completeEffect.Play();

        if (completeEffect != null)
            completeEffect.transform.position = currentWeldPoint;
    }

    private void CompleteWeld()
    {
        IsCompleted = true;
        IsBeingWelded = false;

        currentProgress = weldTimeRequired;

        // Final burst effect
        if (completeEffect != null)
            completeEffect.Play();

        // Stop the loop effect just in case
        if (weldEffectLoop != null)
            weldEffectLoop.Stop();


        OnProgressChanged?.Invoke(1f);

        OnWeldCompleted?.Invoke(this, ItemToCraft);

        Debug.Log($"{name} Weld Complete!");
    }
}
