using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public GameObject[] slots;
    public GameObject[] texts;
    public int i;
    private FadeTutorial displayText;

    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        displayText = GameObject.FindWithTag("Tutorial").GetComponent<FadeTutorial>();
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
                SoundManager.PlaySound("Drop Item");
                inventory.inventory[i] = null;
                Inventory.counter -= 1;
                GameObject.Destroy(child.gameObject);
            }
        }
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
