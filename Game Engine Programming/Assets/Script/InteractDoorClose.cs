using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoorClose : MonoBehaviour
{
    public GameObject currentInterObj = null;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            currentInterObj.SendMessage("DoorOpened");
        }
        if (InteractionObject.opened == true)
        {
            currentInterObj = null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CloseDoor"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CloseDoor"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
    }
}
