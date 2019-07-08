using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    private Inventory full;
    private InteractionDoor finding;
    public GameObject keyGUI;
    public GameObject player;
    public bool inventory;
    public static bool pause;
    public GameObject itemButton;
    public GameObject textButton;
    private bool playBottle;
    public static int firstkey;
    Teleport teleport;

    private void Start()
    {
        full = GameObject.Find("Player").GetComponent<Inventory>();
        teleport = GameObject.FindWithTag("Teleport").GetComponent<Teleport>();
        player = GameObject.Find("Player");
        firstkey = 0;
    }

    public void DoInteraction()
    {
        pause = true;
        if (full.itemAdded == true)
        {
            firstkey++;
            teleport.killerTeleport();
            gameObject.SetActive(false);
            Instantiate(itemButton, full.slots[full.x].transform, false);
            Instantiate(textButton, full.text[full.x].transform, false);
            keyGUI.SetActive(true);
            player.SetActive(false);
            SoundManager.PlaySound("Pickup Key");
        }
        else {
            Debug.Log("Inventory Full");
        }
    }
}
