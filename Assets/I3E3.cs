using UnityEngine;
using UnityEngine.UI;

public class I3E3 : MonoBehaviour
{
    int score = 0;

    // Drag a UI Text object here in the Inspector
    public Text scoreText;

    void Start()
    {
        UpdateScoreUI();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("coin"))
        {
            score++;
            Destroy(collision.gameObject);

            UpdateScoreUI();
            Debug.Log("Coin collected! Score: " + score);

            // Fixed: removed the erroneous semicolon
            {
                OnAllCoinsCollected();
            }
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            
        }
    }

    void OnAllCoinsCollected()
    {
        Debug.Log("All coins collected! You win!");
        // Add your win logic here, e.g.:
        // SceneManager.LoadScene("WinScreen");
        // winPanel.SetActive(true);
    }
}
