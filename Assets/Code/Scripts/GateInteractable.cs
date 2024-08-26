using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class GateInteractable : BaseInteractable
{
    [SerializeField]
    private Animator animatorController;

    private bool IsOpened = false;
    public override void Interact(Action OnInteractionEnd)
    {
        IsOpened = !IsOpened;
        animatorController.SetBool(nameof(IsOpened), IsOpened);
        OnInteractionEnd?.Invoke();
    }
}
