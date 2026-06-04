using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        print("Collison Detected!");
        print($"Collided with:{ collision.gameObject.name}");
    }

    // Update is called once per frame
}
