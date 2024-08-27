using System.Collections;
using TMPro;
using UnityEngine;

public class UnitMove : MonoBehaviour, IExecutable
{

    [SerializeField] 
    private float moveSpeed = 10f;
    private Unit unit;
    private UnitActionType unitActionType;
    private bool isMoving;
    private Vector3 targetPosition;

    private void Start()
    {
        unit = GetComponent<Player>().GetUnit();
        unit.AddActionList(this);
        unitActionType = UnitActionType.MoveAction;
    }

    private void Update()
    {
        if (!isMoving)
        {
            return;
        }

        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
        }
        else
        {
            transform.position = targetPosition;
            isMoving = false;
            unit.GetAnimationController().PlayIdle();
        }
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
        this.targetPosition = hitPosition;
        isMoving = true;
        unit.GetAnimationController().PlayRun();
    }
}
