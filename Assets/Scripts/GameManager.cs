using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalCoins = 0;       // Set this in the Inspector
    private int collectedCoins = 0;

    void Awake()
    {
        Instance = this;
    }

    public void CollectCoin()
    {
        collectedCoins++;
        Debug.Log($"Coins: {collectedCoins}/{totalCoins}");
    }

    public bool AllCoinsCollected()
    {
        return collectedCoins >= totalCoins;
    }
}