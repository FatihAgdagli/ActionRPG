using UnityEngine;

public class Player : MonoBehaviour, ISelectable
{
    [SerializeField]
    private UnitType unitType;
    [SerializeField]
    private GameObject selectedUI;

    private Unit unit;

    private void Awake()
    {
        unit = new Unit(unitType, transform);
        selectedUI.SetActive(false);
    }

    public Unit Select()
    {
        selectedUI.SetActive(true);
        return unit;
    }

    public void Deselect()
    {
        selectedUI.SetActive(false);
    }

    public Unit GetUnit() => unit;
}
