using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSyringe : MonoBehaviour
{
    private Slot slot;
    private Player player;
    private Inventory inventory;
    public GameObject timer;
    public ItemPickup item;
    private CountDownAdrenaline countDown;

    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        player = GameObject.Find("Player").GetComponent<Player>();
        countDown = GameObject.Find("Countdown").GetComponent<CountDownAdrenaline>();
    }

    public void useSyringe()
    {
        Used();
        countDown.timer = 6f;
        player.speed = 9f;
        SoundManager.PlaySound("Use Syringe");
        timer.SetActive(true);
        Destroy(gameObject);
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
