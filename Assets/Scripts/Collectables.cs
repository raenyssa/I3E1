using UnityEngine;

public class Collectables : MonoBehaviour
{
   
   public int value = 1;

   public void Collect()
    {
        var audio = GetComponent<AudioSource>();
        audio.Play();

        var renderer = GetComponent<Renderer>();
        renderer.enabled = false;

        Destroy(gameObject, 1);
    }
}
