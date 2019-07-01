using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private Inventory full;
    public GameObject itemButton;
    public GameObject itemUsed;

    private void Start()
    {
        full = GameObject.Find("Player").GetComponent<Inventory>();
    }

    private void Update()
    {

    }

    public void MedicPickup()
    {
        if (full.itemAdded == true)
        {
            gameObject.SetActive(false);
            itemButton.SetActive(true);
            Instantiate(itemButton, full.slots[full.x].transform, false);
            SoundManager.PlaySound("Medicine Pickup");
        }
        else
        {
            Debug.Log("full inventory");
        }
    }

    public void Used()
    {
        for (int x = 0; x < full.inventory.Length; x++)
        {
            if (full.inventory[x] == itemUsed)
            {
                full.inventory[x] = null;
                SoundManager.PlaySound("Unlock");
            }
        }
    }
}
