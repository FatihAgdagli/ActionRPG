using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    public UnitType UnitType { get; private set; }

    private List<UnitAction> unitActionList;
    private Transform transform;

    public Unit(UnitType unitType, Transform transform)
    {
        UnitType = unitType;
        this.transform = transform;
        InitializeActions();
    }

    private void InitializeActions()
    {
        unitActionList = new List<UnitAction>
        {
            new MoveAction(this),
            new AttackAction(this)
        };

        switch (UnitType)
        {
            case UnitType.Assassin:
                unitActionList.Add(new OpenGateAction(this));
                break;

            case UnitType.Warrior:
                unitActionList.Add(new BreakeAction(this));
                break;
        }
    }

    public string GetActions()
    {
        string actionNames = "";
        foreach (var action in unitActionList)
        {
            actionNames += action.ToString() + " ";
        }
        return actionNames;
    }

    public Transform GetTransform() => transform;
}

public enum UnitType
{
    Assassin,
    Warrior,
}