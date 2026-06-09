using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int totalCoins;
    private int collectedCoins = 0;

    void Awake()
    {
        Instance = this;
        // Count all coins in the scene at start
        totalCoins = FindObjectsOfType<Collectables>().Length;
    }

    public void CollectCoin()
    {
        collectedCoins++;
        if (collectedCoins >= totalCoins)
        {
            FinalDoor.Instance.OpenDoor();
        }
    }
}
