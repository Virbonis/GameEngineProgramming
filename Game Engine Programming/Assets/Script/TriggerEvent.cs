using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public GameObject Activate;
    public GameObject Gore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            gameObject.SetActive(false);
            Activate.SetActive(true);
            Gore.SetActive(true);
        }
    }
}
