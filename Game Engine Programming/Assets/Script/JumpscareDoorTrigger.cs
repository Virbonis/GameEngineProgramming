using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareDoorTrigger : MonoBehaviour
{
    public GameObject suspense1;
    public GameObject door;
    public GameObject otherSameTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            suspense1.SetActive(true);
            door.SetActive(true);
            otherSameTrigger.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
