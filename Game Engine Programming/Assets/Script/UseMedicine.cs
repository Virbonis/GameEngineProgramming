using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMedicine : MonoBehaviour
{
    private Slot slot;
    private Inventory inventory;
    public ItemPickup item;
    public int temp;
    private FadeTutorial health;
    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        slot = GameObject.FindWithTag("Slot").GetComponent<Slot>();
        health = GameObject.FindWithTag("Tutorial").GetComponent<FadeTutorial>();
        item = GetComponent<ItemPickup>();
    }

    public void useMedicine() {
        if (Health.health > 2)
        {
            health.fullHealthDisplay();
        }
        else {
            Used();
            health.pointerDestroy();
            Debug.Log(Inventory.counter);
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
                inventory.inventory[x] = null;
                Inventory.counter -= 1;
            }
        }
    }
}
