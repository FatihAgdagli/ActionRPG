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
    private bool IsOpening = false;
    private bool IsClosing = false;
    private int actionMeter = 0;
    private float closingTimeInSecond = 3f;

    private Action OnInteractionEnd;

    private void Update()
    {
        HandleOpening();
        HandleClosing();
    }

    public override void Interact(Action OnInteractionEnd)
    {
        this.OnInteractionEnd = OnInteractionEnd;
        if (IsOpened)
        {
            IsClosing = true;
        }
        else
        {
            IsOpening = true;
            StartCoroutine(StartOpenDrag());
        }
    }
    
    private void HandleOpening()
    {
        if (!IsOpening)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            actionMeter += 10;
            Debug.Log(actionMeter);
            if (actionMeter >= 100)
            {
                actionMeter = 100;
                animatorController.SetBool(nameof(IsOpened), true);
                OnInteractionEnd?.Invoke();
                IsOpening = false;
                IsOpened = true;
            }
        }

        
    }
    private void HandleClosing()
    {
        if (!IsClosing)
        {
            return;
        }

        StartCoroutine(StartClosing());
    }
    private IEnumerator StartClosing()
    {
        yield return new WaitForSeconds(closingTimeInSecond);
        animatorController.SetBool(nameof(IsOpened), false);
        OnInteractionEnd?.Invoke();
        IsClosing = false;
        IsOpened = false;
    }
    private IEnumerator StartOpenDrag()
    {
        while (IsOpening)
        {
            yield return new WaitForSeconds(1f);
            if(actionMeter > 0)
                actionMeter -= 5;
            Debug.Log(actionMeter);
        }
    }
}
