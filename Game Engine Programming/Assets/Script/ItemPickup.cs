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
    public GameObject doors;
    public GameObject AoOni;
    public GameObject Pause;
    SpriteRenderer rend;
    private FadeTutorial tutorial;

    private void Start()
    {
        full = GameObject.Find("Player").GetComponent<Inventory>();
        tutorial = GameObject.FindWithTag("Tutorial").GetComponent<FadeTutorial>();
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
    }

    public void SyringePickup()
    {
        if (full.itemAdded == true)
        {
            gameObject.SetActive(false);
            itemButton.SetActive(true);
            Instantiate(itemButton, full.slots[full.x].transform, false);
            SoundManager.PlaySound("Pickup Syringe");
            tutorial.useSyringe();
        }
    }

    public void TrapPickUp() {
        gameObject.SetActive(false);
        doors.SetActive(false);
        AoOni.SetActive(true);
        note.SetActive(true);
        Pause.SetActive(false);
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
