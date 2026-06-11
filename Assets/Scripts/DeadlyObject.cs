using UnityEngine;

public class DeadlyObject : MonoBehaviour
{
    public bool instantKill = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
                playerHealth.TakeDamage(instantKill);
        }
    }
}