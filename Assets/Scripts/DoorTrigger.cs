using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject myDoor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger");
            myDoor.GetComponent<DoorOnTrigger>().Interact();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myDoor.GetComponent<DoorOnTrigger>().Interact();
        }

    }
}