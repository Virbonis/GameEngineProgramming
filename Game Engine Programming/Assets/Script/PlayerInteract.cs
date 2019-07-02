using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public GameObject currentItem = null;
    public GameObject currentNote = null;
    public GameObject DoorClose = null;
    public GameObject DoorOpen = null;
    public GameObject DoorLock = null;
    public InteractionObject currentInterScript = null;
    public Inventory inventory;
    public InteractionDoor key;
    public InteractionObject keyGUI;
    public bool pressed_Open;
    public bool pressed_Locked;
    public bool pressed_Close;

    void Start()
    {
        key = GameObject.FindWithTag("LockedDoor").GetComponent<InteractionDoor>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            inventory.addItem(currentInterObj);
            currentInterObj.SendMessage("DoInteraction");
            currentInterObj = null;
        }

        if (Input.GetButtonDown("Interact") && currentItem)
        {
            inventory.addItem(currentItem);
            currentItem.SendMessage("MedicPickup");
            currentItem = null;
        }

        if (Input.GetButtonDown("Interact") && currentNote)
        {
            currentNote.SendMessage("NotePickup");
            currentNote = null;
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

        if (Input.GetButtonDown("Interact") && pressed_Locked == true)
        {
            DoorLock.SendMessage("DoorInteractionLocked");
            pressed_Open = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InterObject"))
        {
            currentInterObj = other.gameObject;
            currentInterScript = currentInterObj.GetComponent<InteractionObject>();
        }

        if (other.CompareTag("Item"))
        {
            currentItem = other.gameObject;
        }

        if (other.CompareTag("Note"))
        {
            currentNote = other.gameObject;
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

        if (other.CompareTag("LockedDoor")) {
            pressed_Locked = true;
            DoorLock = other.gameObject;
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

        if (other.CompareTag("Item"))
        {
            if (other.gameObject == currentItem)
            {
                currentItem = null;
            }
        }

        if (other.CompareTag("Note"))
        {
            if (other.gameObject == currentNote)
            {
                currentNote = null;
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

        if (other.CompareTag("LockedDoor"))
        {
            pressed_Locked = false;
            if (other.gameObject == DoorLock)
            {
                DoorLock = null;
            }
        }
    }
}
