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
        SetDoor(false);
        return;
    }

    if (!GameManager.Instance.AllCoinsCollected())
    {
        PopupText.Instance.Show("Collect all coins first!", 2.5f);  // ← add this
        return;
    }

    PopupText.Instance.Show("Door unlocked!", 2f);  // ← add this
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