using UnityEngine;

public class UnitBreak : MonoBehaviour, IExecutable
{
    private Unit unit;
    private UnitActionType unitActionType;

    private void Start()
    {
        unit = GetComponent<Player>().Select();
        unit.AddActionList(this);
        unitActionType = UnitActionType.BreakAction;
    }

    public UnitActionType GetUnitActionType()
    {
        return unitActionType;
    }

    public void Trigger(Transform targetPosition, Vector3 hitPosition)
    {
        hitPosition.y = 0;
        Vector3 directionNormilzed = (hitPosition - transform.position).normalized;

        transform.forward = directionNormilzed;
    }
}
