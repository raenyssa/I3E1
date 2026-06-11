using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth, maxHealth, damageAmount;
    public GameObject DamageEffect;

    public HealthBar healthBar;

    [Header("Health Bar")]
    public float respawnTime = 2f;
    public Vector3 SpawnPosition;
    public Transform respawnPoint;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    void Update()
    {
        
    }
    
    public void TakeDamage(bool instantKill = false)
{
    if (isDead) return;

    if (instantKill)
        currentHealth = 0;
    else
        currentHealth -= damageAmount;

    healthBar.SetHealth(currentHealth);

    if (currentHealth <= 0)
        Die();
}

    void Die()
    {isDead = true;

        // Play death effect here (animation, sound, particles, etc.)
        Debug.Log("Player died!");

        // Respawn after delay instead of reloading the scene
        Invoke(nameof(Respawn), respawnTime);
    }

    void Respawn()
    {
        transform.position = respawnPoint != null ? respawnPoint.position : SpawnPosition;

        // Reset health
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        healthBar.SetMaxHealth(currentHealth);

        isDead = false;

        Debug.Log("Player respawned!");
    }

    // Optional: call this if you still want a full scene reload instead
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
