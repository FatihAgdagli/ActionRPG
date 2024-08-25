public abstract class UnitAction
{
    public UnitActionType UnitActionType { get; protected set; }
    public Unit Unit { get; protected set; }

    public UnitAction(Unit unit)
    {
        Unit = unit;
    }

    public abstract void Trigger();
}

public class MoveAction : UnitAction
{
    public MoveAction(Unit unit) : base(unit)
    {
        UnitActionType = UnitActionType.MoveAction;
    }

    public override void Trigger()
    {
        
    }
}

public class OpenGateAction : UnitAction
{
    public OpenGateAction(Unit unit) : base(unit)
    {
        UnitActionType = UnitActionType.OpenGateAction;
    }

    public override void Trigger()
    {

    }
}

public class AttackAction : UnitAction
{
    public AttackAction(Unit unit) : base(unit)
    {
        UnitActionType = UnitActionType.AttackAction;
    }

    public override void Trigger()
    {

    }
}

public class BreakeAction : UnitAction
{
    public BreakeAction(Unit unit) : base(unit)
    {
        UnitActionType = UnitActionType.BreakeAction;
    }

    public override void Trigger()
    {

    }
}

public enum UnitActionType
{
    MoveAction,
    OpenGateAction, 
    AttackAction,
    BreakeAction,
}