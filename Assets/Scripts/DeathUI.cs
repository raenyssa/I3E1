using UnityEngine;
using TMPro; // or use UnityEngine.UI if you're using legacy Text
using System.Collections;
 
public class DeathUI : MonoBehaviour
{
    public static DeathUI Instance;
 
    [Header("UI References")]
    public GameObject deathPanel;           // The popup panel GameObject
    public TextMeshProUGUI deathMessageText; // The text inside the panel
 
    [Header("Settings")]
    public string deathMessage = "YOU DIED";
    public float displayDuration = 2f;      // How long to show the popup
 
    void Awake()
    {
        // Singleton so PlayerHealth can find it easily
        Instance = this;
        deathPanel.SetActive(false);
    }
 
    public void ShowDeathPopup()
    {
        deathMessageText.text = deathMessage;
        deathPanel.SetActive(true);
        StartCoroutine(HideAfterDelay());
    }
 
    IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        deathPanel.SetActive(false);
    }
}
