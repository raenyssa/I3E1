using UnityEngine;

public class Coincollisionscript : MonoBehaviour
{
    int score = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("coin"))
        { score++;
        print($"Current Score:{score}");
        Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            print("You collected all the coins!" + score);
        }
    }
}
