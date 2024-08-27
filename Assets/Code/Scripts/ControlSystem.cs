using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTarget;
    [SerializeField]
    private LayerMask groundLayerMask;

    private Unit selectedUnit;
    private bool isBusy = false;

    private Vector2 screenSize;
    private float edgeDistance = 100f;
    private float cameraMoveSpeed = 10f;

    private void Awake()
    {
        screenSize = new Vector2(Screen.currentResolution.width, 
                                 Screen.currentResolution.height);
    }

    private void Update()
    {
        HandleCameraMovement();

        HangleUnitActions();

        isBusy = false;
    }

    private void HangleUnitActions()
    {
        // No GameObject
        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            return;
        }

        HandleUnitSelect(ref hit);

        HandleMoveAction();

        HandleInteractabeles(ref hit);
    }

    private void HandleInteractabeles(ref RaycastHit hit)
    {
        if (isBusy)
        {
            return;
        }
        //No unit to move
        if (selectedUnit == null)
        {
            return;
        }
        // No Mouse button click
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }
        if(hit.transform.TryGetComponent(out IInteractable interactable)) 
        {
            //Debug.Log(hit.point);
            
            float distance = Vector3.Distance(hit.point, selectedUnit.GetTransform().position);
            if (distance < interactable.GetInteractionRange())
            {
                selectedUnit.TriggerAction(UnitActionType.OpenGateAction, hit.transform, hit.point);
                isBusy = true;
            }
        }
    }

    private void HandleCameraMovement()
    {
        Vector3 cameraMovement =  Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            cameraMovement.z = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            cameraMovement.z = -1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            cameraMovement.x = -1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            cameraMovement.x = 1f;
        }
        //Debug.Log(cameraMovement);
        cameraTarget.transform.Translate(cameraMovement * cameraMoveSpeed * Time.deltaTime);
    }

    private void HandleMoveAction()
    {
        if (isBusy)
        {
            return;
        }
        //No unit to move
        if (selectedUnit == null)
        {
            return;
        }
        // No Mouse button click
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), 
            out RaycastHit hit, float.MaxValue, groundLayerMask))
        {
            //Debug.Log(hit.point);
            selectedUnit.TriggerAction(UnitActionType.MoveAction, hit.transform, hit.point);
            isBusy = true;
        }

    }

    private void HandleUnitSelect(ref RaycastHit hit)
    {
        if (isBusy)
        {
            return;
        }
        // No Mouse button click
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }
        // No Selectable
        if (!hit.transform.root.TryGetComponent(out ISelectable selectable))
        {
            return;
        }
        if (selectedUnit != null)
        {
            selectedUnit.GetTransform().
                GetComponent<ISelectable>().
                Deselect();
        }
        selectedUnit = selectable.Select();
        isBusy = true;
    }
}
