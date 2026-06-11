using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 rotateAmount = new Vector3(0, 90, 0);
    public float interactDistance = 3f;
    bool isOpen = false;

    public void Interact()
    {
        var animator = GetComponent<Animator>();
        animator.SetBool("isOpen", !isOpen);
        isOpen = !isOpen;
        print("Door Interacted");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsLookingAtDoor())
                Interact();
        }
    }

    bool IsLookingAtDoor()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            return hit.transform == transform;
        }
        return false;
    }
}
