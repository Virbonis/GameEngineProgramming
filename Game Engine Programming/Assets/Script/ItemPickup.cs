using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private Inventory full;
    public GameObject itemButton;
    public GameObject itemUsed;
    public GameObject note;
    public GameObject text;
    public GameObject map;
    SpriteRenderer rend;
    FadeInClue clue;
    private FadeTutorial tutorial;

    private void Start()
    {
        full = GameObject.Find("Player").GetComponent<Inventory>();
        tutorial = GameObject.FindWithTag("Tutorial").GetComponent<FadeTutorial>();
        clue = GameObject.FindWithTag("Clue GUI").GetComponent<FadeInClue>();
    }

    public void MedicPickup()
    {
        if (full.itemAdded == true)
        {
            gameObject.SetActive(false);
            itemButton.SetActive(true);
            Instantiate(itemButton, full.slots[full.x].transform, false);
            SoundManager.PlaySound("Medicine Pickup");
            tutorial.UseItem();
        }
        else {
            Debug.Log("Inventory Full");
        }
    }

    public void NotePickup() {
        gameObject.SetActive(false);
        text.SetActive(true);
        note.SetActive(true);
    }

    public void MapPickup() {
        note.SetActive(true);
        SoundManager.PlaySound("Note Pickup");
    }
}
