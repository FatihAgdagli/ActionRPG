using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; }

    [SerializeField]
    private GameObject actionBarGO;
    public Image actionBarImage;

    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        actionBarGO.SetActive(false);
    }

    private void Start()
    {
        GateInteractable.OnAnyGateInteractStarted += GateInteractable_OnAnyGateInteractStarted;
        GateInteractable.OnAnyGateInteractEnded += GateInteractable_OnAnyGateInteractEnded;
        GateInteractable.OnAnyActionMeterChanged += GateInteractable_OnAnyActionMeterChanged;
    }

    private void OnDisable()
    {
        GateInteractable.OnAnyGateInteractStarted -= GateInteractable_OnAnyGateInteractStarted;
        GateInteractable.OnAnyGateInteractEnded -= GateInteractable_OnAnyGateInteractEnded;
        GateInteractable.OnAnyActionMeterChanged -= GateInteractable_OnAnyActionMeterChanged;
    }

    private void GateInteractable_OnAnyActionMeterChanged(float fillAmount)
    {
        actionBarImage.fillAmount = fillAmount;
    }

    private void GateInteractable_OnAnyGateInteractEnded()
    {
        actionBarGO.SetActive(false);
        actionBarImage.fillAmount = 0;
    }

    private void GateInteractable_OnAnyGateInteractStarted()
    {
        actionBarGO.SetActive(true);
    }


}
