using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDoor : MonoBehaviour
{
    public GameObject doorOpened;
    public GameObject doorClosed;
    public GameObject doorLocked;
    public PlayerInteract playerInteraction;
    public GameObject itemNeeded;
    public Inventory finding;
    private bool find;

    void Start()
    {
        playerInteraction = GameObject.Find("Player").GetComponent<PlayerInteract>();
        finding = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void DoorInteractionOpen()
    {
        doorOpened.SetActive(true);
        doorClosed.SetActive(false);
        SoundManager.PlaySound("Open Door");
    }

    public void DoorInteractionClose()
    {
        doorOpened.SetActive(false);
        doorClosed.SetActive(true);
        SoundManager.PlaySound("Close Door");
    }

    public void DoorInteractionLocked() {
        for (int x = 0; x < finding.inventory.Length; x++)
        {
            if (finding.inventory[x] == itemNeeded)
            {
                finding.inventory[x] = null;
                find = true;
                SoundManager.PlaySound("Unlock");
            }
        }

        if (find == true)
        {
            doorLocked.SetActive(false);
            doorClosed.SetActive(true);
        }
        else {
            SoundManager.PlaySound("Locked Door");
        }
    }
}
