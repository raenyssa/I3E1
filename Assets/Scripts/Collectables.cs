using UnityEngine;

public class Collectables : MonoBehaviour
{
   
   bool isCollected = false;
   public int value = 1;

   public void Collect()
    {
        GameManager.Instance.CollectCoin();
        var audio = GetComponent<AudioSource>();
        audio.Play();

        var renderer = GetComponent<Renderer>();
        renderer.enabled = false;

        Destroy(gameObject, 1);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !isCollected)
        {
            isCollected = true;
            Collect();
        }
    }
}
