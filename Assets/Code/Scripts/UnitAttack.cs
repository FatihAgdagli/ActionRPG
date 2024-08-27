using UnityEngine;

public class UnitAttack : MonoBehaviour, IExecutable
{
    private Unit unit;
    private UnitActionType unitActionType;

    private void Start()
    {
        unit = GetComponent<Player>().GetUnit();
        unit.AddActionList(this);
        unitActionType = UnitActionType.AttackAction;
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
