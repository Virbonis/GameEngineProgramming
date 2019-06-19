using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public GameObject DoorClose = null;
    public GameObject DoorOpen = null;
    public bool pressed_Open;
    public bool pressed_Close;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            currentInterObj.SendMessage("DoInteraction");
        }

        if (Input.GetButtonDown("Interact") && pressed_Open == true)
        {
            DoorClose.SendMessage("DoorInteractionOpen");
            pressed_Open = false;
        }

        if (Input.GetButtonDown("Interact") && pressed_Close == true)
        {
            DoorOpen.SendMessage("DoorInteractionClose");
            pressed_Close = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InterObject"))
        {
            currentInterObj = other.gameObject;
        }

        if (other.CompareTag("CloseDoor")) {
            pressed_Open = true;
            DoorClose = other.gameObject;
        }

        if (other.CompareTag("OpenDoor"))
        {
            pressed_Close = true;
            DoorOpen = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InterObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }

        if (other.CompareTag("CloseDoor"))
        {
            pressed_Open = false;
            if (other.gameObject == DoorClose)
            {
                DoorClose = null;
            }
        }

        if (other.CompareTag("OpenDoor"))
        {
            pressed_Close = false;
            if (other.gameObject == DoorOpen)
            {
                DoorOpen = null;
            }
        }
    }
}
