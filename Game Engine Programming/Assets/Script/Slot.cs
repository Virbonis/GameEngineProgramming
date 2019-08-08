using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public GameObject[] slots;
    public GameObject[] texts;
    public GameObject item;
    public int i;
    private FadeTutorial displayText;
    private Transform player;
    Collider2D colliderItem;
    ItemPickup itemPickUp;

    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        displayText = GameObject.FindWithTag("Tutorial").GetComponent<FadeTutorial>();
        player = GameObject.Find("Player").transform;
    }

    public void DoorInteraction() {
        GameObject.Destroy(slots[InteractionDoor.temp].transform.GetChild(0).gameObject);
        Inventory.counter -= 1;
    }

    public void DestroyTextUI() {
        GameObject.Destroy(texts[InteractionDoor.temp].transform.GetChild(0).gameObject);
    }

    public void DropItem() {
        foreach (Transform child in transform) {
            if (child.tag == "Key")
            {
                displayText.CantDrop();   
            }
            else
            {
                spawnItem();
                Destroy(inventory.inventory[i]);
                SoundManager.PlaySound("Drop Item");
                displayText.pointerDestroy();
                inventory.inventory[i] = null;
                Inventory.counter -= 1;
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    public void spawnItem() {
        inventory.inventory[i].SetActive(true);
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        Instantiate(inventory.inventory[i], playerPos, Quaternion.identity);
    }

    public void DestroyTextItem()
    {
        foreach (Transform child in transform)
        {
            if (child.tag != "Key")
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
