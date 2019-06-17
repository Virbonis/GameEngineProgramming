using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    public static bool GUI_pause;
    public static bool opened;
    public static bool closed;
    public GameObject doorOpened;
    public GameObject doorClosed;

    public void DoInteraction()
    {
        gameObject.SetActive(false);
        GUI_pause = true;
    }

    public void DoorOpened() {
        doorOpened.SetActive(true);
        opened = true;
        closed = false;
        this.gameObject.SetActive(false);
    }

    public void DoorClosed()
    {
        doorClosed.SetActive(true);
        opened = false;
        closed = true;
        this.gameObject.SetActive(false);
    }
}
