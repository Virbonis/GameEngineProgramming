using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory;
    public GameObject[] slots;
    public GameObject[] text;
    public bool itemAdded;
    public int counter;
    public int x;

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
    }
}
