using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class GateInteractable : BaseInteractable
{
    public static event Action OnAnyGateInteractStarted;
    public static event Action OnAnyGateInteractEnded;
    public static event Action<float> OnAnyActionMeterChanged;

    [SerializeField]
    private Animator animatorController;

    private bool IsOpened = false;
    private bool IsOpening = false;
    private bool IsClosing = false;
    private bool IsAnyActionKeyPressed= false;
    private int actionMeter = 0;
    private float closingTimeInSecond = 1f;

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
            IsAnyActionKeyPressed = false;
            OnAnyGateInteractStarted?.Invoke();
            actionMeter = 0;
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
            IsAnyActionKeyPressed = true;
            actionMeter += 10;
            OnAnyActionMeterChanged?.Invoke(((float)actionMeter)/100f);
            if (actionMeter >= 100)
            {
                actionMeter = 100;
                animatorController.SetBool(nameof(IsOpened), true);
                IsOpening = false;
                IsOpened = true;
                IsAnyActionKeyPressed = false;
                OnAnyGateInteractEnded?.Invoke();
                OnInteractionEnd?.Invoke();
            }
        }

        
    }
    private IEnumerator StartOpenDrag()
    {
        while (IsOpening)
        {
            yield return new WaitForSeconds(.5f);
            if(actionMeter > 0)
                actionMeter -= 5;

            if (IsAnyActionKeyPressed && actionMeter <= 0)
            {
                actionMeter = 0;
                IsOpening = false;
                animatorController.SetBool(nameof(IsOpened), false);
                OnInteractionEnd?.Invoke();
                OnAnyGateInteractEnded?.Invoke();
            }
            OnAnyActionMeterChanged?.Invoke(((float)actionMeter) / 100f);
        }
    }
    
    private void HandleClosing()
    {
        if (!IsClosing)
        {
            return;
        }
        IsClosing = false;
        StartCoroutine(StartClosing());
    }
    private IEnumerator StartClosing()
    {
        yield return new WaitForSeconds(closingTimeInSecond);
        animatorController.SetBool(nameof(IsOpened), false);
        OnInteractionEnd?.Invoke();
        IsOpened = false;
    }
}
