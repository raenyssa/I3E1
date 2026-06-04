using UnityEngine;
using UnityEngine.InputSystem;

public class Coincollisionscript : MonoBehaviour
{
    int score = 0;

    bool isMenuShowing = false;

    public UIManager MyUIManager;

    void OnMenu()
    {
        MyUIManager.ShowMenu(!isMenuShowing);
        isMenuShowing = !isMenuShowing;
    }

    GameObject currentCollidor;
    GameObject lastTrigger;
    int totalscore = 0;

    void OnCollisionEnter(Collision collision)
    {
       currentCollidor = collision.gameObject;
       print($"Collided with {currentCollidor.name}");
    }

    void OnCollisionExit(Collision collision)
    {
        currentCollidor = null;
        print($"Stopped colliding with {collision.gameObject.name}");

    }

    void OnInteract(InputValue value)
    {
        print($"Interacting with {currentCollidor?.name}");
        if(currentCollidor != null)
        {
            var collectible = currentCollidor.GetComponent<Collectables>();
            if(collectible != null)
            {
                print($"Interacting with {currentCollidor.name}");
                totalscore += collectible.value;
                MyUIManager.SetScore(totalscore);
                Destroy(currentCollidor);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="finish"&&score==5)
        {
            print($"Final score: {score}"); 
        }
        else 
        {
            print($"Final score: {score}");
        }
    }
}
