using UnityEngine;

public class HazardDamage : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
       if (other.CompareTag("Player"))
        {
            PlayerHealth playerhealth = other.gameObject.transform.parent.GetComponent<PlayerHealth>();
            playerhealth.TakeDamage();
            Debug.Log("Hazard Triggered");
        }

    }
    
}