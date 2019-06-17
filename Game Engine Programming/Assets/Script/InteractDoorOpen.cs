using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoorOpen : MonoBehaviour
{
    public GameObject currentInterObj = null;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            currentInterObj.SendMessage("DoorClosed");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("OpenDoor"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("OpenDoor"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }

        }
    }
}
