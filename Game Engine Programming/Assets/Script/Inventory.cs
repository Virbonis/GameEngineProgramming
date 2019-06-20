using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory;
    public bool itemAdded;
    public int counter;

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
        for (int x = 0; x < inventory.Length; x++)
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
