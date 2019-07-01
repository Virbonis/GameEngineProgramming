using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMedicine : MonoBehaviour
{
    private Slot slot;
    private Inventory inventory;
    public ItemPickup item;
    public int temp;

    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        slot = GameObject.FindWithTag("Slot").GetComponent<Slot>();
    }

    public void useMedicine() {
        if (Health.health >= 3)
        {
            Debug.Log("Your health is full");
        }
        else {
            Used();
            Health.health += 1;
            SoundManager.PlaySound("Healing");
            Destroy(gameObject);
        }
    }

    public void Used()
    {
        for (int x = 0; x < inventory.inventory.Length; x++)
        {
            if (inventory.inventory[x] == item.itemUsed)
            {
                temp = x;
                inventory.inventory[x] = null;
                SoundManager.PlaySound("Unlock");
            }
        }
    }
}
