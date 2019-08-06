using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory;
    public GameObject[] slots;
    public GameObject[] text;
    public bool itemAdded;
    public static int counter = 0;
    public int x;
    private FadeTutorial displayFullInventory;
    private Teleport teleport;
    public GameObject[] keys;
    public GameObject[] items;

    private void Start()
    {
        counter = 0;
        displayFullInventory = GameObject.FindWithTag("Tutorial").GetComponent<FadeTutorial>();
        teleport = GameObject.FindWithTag("Teleport").GetComponent<Teleport>();
    }

    void Update()
    {
        if (inventory.Length == counter)
        {
            itemAdded = false;
        }
        else {
            itemAdded = true;
        }
    }

    public void addItem(GameObject item)
    {
        for (x = 0; x < inventory.Length; x++)
        {
            if (inventory[x] == null)
            {
                inventory[x] = item;
                counter++;
                itemAdded = true;
                break;
            }
        }

        if (itemAdded == false) {
            displayFullInventory.fullInventory();
        }
    }

    public void SearchItem()
    {
        for (int x = 0; x < inventory.Length; x++)
        {
            if (inventory[x] == keys[0])
            {
                teleport.killerTeleport();
            }
            else if (inventory[x] == keys[1]) {
                teleport.SetActiveObject();
            }
        }
    }
}
