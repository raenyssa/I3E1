using UnityEngine;

public class Collectables : MonoBehaviour
{
   
   public int score = 1;

   public void Collect()
    {
        Destroy(gameObject);
    }
}
