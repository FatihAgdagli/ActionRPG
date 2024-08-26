using UnityEngine;

public interface IExecutable
{
    void Trigger(Transform targetTransform, Vector3 hitPosition);

    UnitActionType GetUnitActionType();
}
public enum UnitActionType
{
    MoveAction,
    OpenGateAction, 
    AttackAction,
    BreakAction,
}

//public abstract class UnitAction
//{
//    public UnitActionType UnitActionType { get; protected set; }
//    public Unit Unit { get; protected set; }

//    public UnitAction(Unit unit)
//    {
//        Unit = unit;
//    }

//    public abstract void Trigger(Transform target);
//}

//public class MoveAction : UnitAction
//{
//    public MoveAction(Unit unit) : base(unit)
//    {
//        UnitActionType = UnitActionType.MoveAction;
//    }

//    public override void Trigger(Transform target)
//    {



//        Debug.Log("Move action triggered");
//    }
//}

//public class OpenGateAction : UnitAction
//{
//    public OpenGateAction(Unit unit) : base(unit)
//    {
//        UnitActionType = UnitActionType.OpenGateAction;
//    }

//    public override void Trigger(Transform target)
//    {
//        Debug.Log("OpenGate action triggered");
//    }
//}

//public class AttackAction : UnitAction
//{
//    public AttackAction(Unit unit) : base(unit)
//    {
//        UnitActionType = UnitActionType.AttackAction;
//    }

//    public override void Trigger(Transform target)
//    {
//        Debug.Log("Attack action triggered");
//    }
//}

//public class BreakAction : UnitAction
//{
//    public BreakAction(Unit unit) : base(unit)
//    {
//        UnitActionType = UnitActionType.BreakAction;
//    }

//    public override void Trigger(Transform target)
//    {
//        Debug.Log("Break action triggered");
//    }
//}
