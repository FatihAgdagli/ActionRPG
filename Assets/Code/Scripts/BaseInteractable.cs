using System;
using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private float interactionRange = 2.0f;

    public float GetInteractionRange()
    {
        return interactionRange;
    }

    public abstract void Interact(Action OnInteractionEnd);
}
