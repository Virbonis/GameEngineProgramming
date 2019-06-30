using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public GameObject[] slots;
    public GameObject[] texts;
    private Spawn spawning;
    public int i;

    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void DoorInteraction() {
        GameObject.Destroy(slots[InteractionDoor.temp].transform.GetChild(0).gameObject);
    }

    public void DestroyTextUI() {
        GameObject.Destroy(texts[InteractionDoor.temp].transform.GetChild(0).gameObject);
    }

    public void DropItem() {
        foreach (Transform child in transform) {
            inventory.inventory[i] = null;
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }

    public void DestroyTextItem()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
