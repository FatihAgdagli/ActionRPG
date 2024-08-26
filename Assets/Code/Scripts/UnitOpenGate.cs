using UnityEngine;

public class UnitOpenGate : MonoBehaviour, IExecutable
{
    private Unit unit;
    private UnitActionType unitActionType;

    private void Start()
    {
        unit = GetComponent<Player>().Select();
        unit.AddActionList(this);
        unitActionType = UnitActionType.OpenGateAction;
    }

    public UnitActionType GetUnitActionType()
    {
        return unitActionType;
    }

    public void Trigger(Transform targetTransform, Vector3 hitPosition)
    {
        hitPosition.y = 0;
        Vector3 directionNormilzed = (hitPosition - transform.position).normalized;

        transform.forward = directionNormilzed;
        unit.GetAnimationController().PlayWorkingOnDevice();
        targetTransform.GetComponent<IInteractable>().Interact(OnActionEnd);
    }

    private void OnActionEnd()
    {
        unit.GetAnimationController().PlayIdle();
    }
}
