using Cinemachine;
using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;
    private Unit selectedUnit;


    private void Update()
    {
        // No GameObject
        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            return;
        }

        HandleUnitSelect(hit);
    }

    private void HandleUnitSelect(RaycastHit hit)
    {
        // No Mouse button click
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        // No Selectable
        if (!hit.transform.root.TryGetComponent(out ISelectable selectable))
        {
            return;
        }

        selectedUnit = selectable.Select();
        virtualCamera.Follow = selectedUnit.GetTransform();

        Debug.Log(selectedUnit.GetActions());
    }
}
