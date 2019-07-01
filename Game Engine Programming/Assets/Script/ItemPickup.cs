using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private Inventory full;
    public GameObject itemButton;
    public GameObject textButton;

    private void Start()
    {
        full = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void MedicPickup()
    {
        if (full.itemAdded == true)
        {
            gameObject.SetActive(false);
            Instantiate(itemButton, full.slots[full.x].transform, false);
            SoundManager.PlaySound("Medicine Pickup");
        }
        else
        {
            Debug.Log("full inventory");
        }
    }
}
