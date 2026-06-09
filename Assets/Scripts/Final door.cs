// FinalDoor.cs
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public static FinalDoor Instance;

    [Header("Animation")]
    public Animator doorAnimator; // optional, if using Animator
    public float openAngle = 90f; // optional, if using rotation

    void Awake()
    {
        Instance = this;
    }

    public void OpenDoor()
    {
        // Option A — using Animator
        if (doorAnimator != null)
            doorAnimator.SetTrigger("Open");

        // Option B — simple rotation (uncomment if not using Animator)
        // transform.rotation = Quaternion.Euler(0, openAngle, 0);

        // Option C — disable the collider so the player can pass through
        // GetComponent<Collider>().enabled = false;
    }
}