using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpotLight : MonoBehaviour
{
    public GameObject[] Activate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            for (int x = 0; x < Activate.Length; x++) {
                Activate[x].SetActive(true);
            }
            SoundManager.PlaySound("Spotlight");
        }
    }
}
