using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDoor : MonoBehaviour
{
    public GameObject doorOpened;
    public GameObject doorClosed;
    public PlayerInteract playerInteraction;

    void Start()
    {
        playerInteraction = GameObject.Find("Player").GetComponent<PlayerInteract>();
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
}
