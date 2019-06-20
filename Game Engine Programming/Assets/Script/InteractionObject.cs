using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public static bool GUI_pause;
    private Inventory full;
    public bool inventory;

    private void Start()
    {
        full = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void DoInteraction()
    {
        if (full.itemAdded == true)
        {
            gameObject.SetActive(false);
            SoundManager.PlaySound("Pickup Key");
            GUI_pause = true;
        }
        else {
            Debug.Log("full inventory");
        }
    }
}
