using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit
{
    public UnitType UnitType { get; private set; }

    private List<IExecutable> unitExecuteList;
    private Transform transform;
    private UnitAnimationController animationController;

    public Unit(UnitType unitType, Transform transform)
    {
        UnitType = unitType;
        this.transform = transform;
        animationController = transform.GetComponent<UnitAnimationController>();
        InitializeActions();
    }

    private void InitializeActions()
    {
        unitExecuteList = new List<IExecutable>();
        transform.AddComponent<UnitMove>();
        transform.AddComponent<UnitAttack>();

        switch (UnitType)
        {
            case UnitType.Assassin:
                transform.AddComponent<UnitOpenGate>();
                break;

            case UnitType.Warrior:
                transform.AddComponent<UnitBreak>();
                break;
        }
    }

    public void AddActionList(IExecutable executable) => unitExecuteList.Add(executable);

    public void TriggerAction(UnitActionType action, Transform targetTransform, Vector3 hitPosition)
    {
        IExecutable unitAction = unitExecuteList.Find( a => a.GetUnitActionType() == action );
        unitAction?.Trigger(targetTransform, hitPosition);
    }

    public Transform GetTransform() => transform;

    public UnitAnimationController GetAnimationController() => animationController;
}

public enum UnitType
{
    Assassin,
    Warrior,
}