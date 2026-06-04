using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    int score;

    public TMP_Text scoreText;

    public GameObject MenuPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"{score}";
    }

    public void ShowMenu(bool isVisible)
    {
        MenuPanel.SetActive(isVisible);

        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isVisible;
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
    }
}
