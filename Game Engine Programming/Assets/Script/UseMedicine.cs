using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMedicine : MonoBehaviour
{
    private Slot slot;
    public GameObject item;

    public void useMedicine() {
        if (Health.health >= 3)
        {
            Debug.Log("Your health is full");
        }
        else {
            Health.health += 1;
            SoundManager.PlaySound("Healing");
            Destroy(gameObject);
        }
    }
}
