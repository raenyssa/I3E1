// FinalDoor.cs
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public Vector3 rotateAmount = new Vector3(0, 90, 0);
    bool isOpen = false;

    public void Interact()
    {
        if (isOpen)
        {
            // Always allow closing
            SetDoor(false);
            return;
        }

        if (!GameManager.Instance.AllCoinsCollected())
        {
            Debug.Log("Collect all coins first!");
            return;
        }

        SetDoor(true);
    }

    void SetDoor(bool open)
    {
        var animator = GetComponent<Animator>();
        animator.SetBool("isOpen", open);
        isOpen = open;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Interact();
    }
}