using UnityEngine;

public class DoorObjectTrigger : MonoBehaviour
{
    public Vector3 rotateAmount = new Vector3(0, 90, 0);
    bool isOpen = false;
    bool keyIsNear = false; // tracks if the key is in range

    public void Interact()
    {
        if (!keyIsNear) return; // block interaction if key isn't touching

        var animator = GetComponent<Animator>();
        animator.SetBool("isOpen", !isOpen);
        isOpen = !isOpen;
        print("Door Interacted");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Interact();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
            keyIsNear = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Key"))
            keyIsNear = false;
    }
}
