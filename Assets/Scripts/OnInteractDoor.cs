using UnityEngine;

public class OnInteractDoor : MonoBehaviour
{
    public ButtonDoorController door;
    private bool playerNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }

    private void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.F))
            door.Interact();
    }
}