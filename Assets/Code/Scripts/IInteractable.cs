using System;

internal interface IInteractable
{
    void Interact(Action OnInteraction = null);
    float GetInteractionRange();
}

