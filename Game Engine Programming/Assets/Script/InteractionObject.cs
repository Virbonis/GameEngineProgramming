using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    private Inventory full;
    public GameObject keyGUI;
    public GameObject player;
    public bool inventory;
    public static bool pause;

    private void Start()
    {
        full = GameObject.Find("Player").GetComponent<Inventory>();
        player = GameObject.Find("Player");
    }

    public void DoInteraction()
    {
        pause = true;
        if (full.itemAdded == true)
        {
            gameObject.SetActive(false);
            keyGUI.SetActive(true);
            player.SetActive(false);
            SoundManager.PlaySound("Pickup Key");
        }
        else {
            Debug.Log("full inventory");
        }
    }
}
