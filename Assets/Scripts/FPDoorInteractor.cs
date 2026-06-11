using UnityEngine;

public class FPDoorInteractor : MonoBehaviour
{
    [Header("Raycast Settings")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactableLayer = -1;
    

    [Header("Input")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    private void Awake()
    {
        if (playerCamera == null)
        {
            playerCamera = GetComponent<Camera>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            InteractWithDoor();
        }
    }

    private void InteractWithDoor()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactableLayer))
        {
            DoorController door = hit.collider.GetComponent<DoorController>();
            if (door != null)
            {
                door.ToggleDoor();
            }
        }
    }
}
