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

    private void Start()
    {
        counter = 0;
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
        Debug.Log(counter);
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
