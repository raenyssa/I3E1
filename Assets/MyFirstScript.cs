using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class MyFirstScript : MonoBehaviour
{

    float move = 0.01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print(transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        // Task 1
        transform.position += new Vector3(move,0f,0f);

        // Task 2
        if (transform.position.x > 5f) move = -0.01f;
        if (transform.position.x < -5f) move = 0.01f;

        // Task 3
        transform.Rotate(0, move, 0);

        // Make the object grow larger by 0.1% every frame
        // transform.localScale = transform.localScale * 1.001f;
        

        // How to declare a new variable
        // var x = 1; This is an integer variable
        // var v2 = new Vector2(0, 0);
        // var v3 = new Vector3(0, 0, 0);
        // var v4 = new Vector4(0, 0, 0, 0);
        
    }
}
