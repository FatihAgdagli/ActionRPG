using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit
{
    public UnitType UnitType { get; private set; }

    private List<IExecutable> unitExecuteList;
    private Transform transform;

    public Unit(UnitType unitType, Transform transform)
    {
        UnitType = unitType;
        this.transform = transform;
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

    public void GoTarget(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0;
        transform.forward = direction;
    }
}

public enum UnitType
{
    Assassin,
    Warrior,
}