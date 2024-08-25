using UnityEngine;

public class Player : MonoBehaviour, ISelectable
{
    [SerializeField]
    private UnitType unitType;

    private Unit unit;

    private void Awake()
    {
        unit = new Unit(unitType, transform);
    }
    public Unit Select() => unit;
}
