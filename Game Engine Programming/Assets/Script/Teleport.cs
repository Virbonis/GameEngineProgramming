using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject target;
    public GameObject targetOutside;
    private Transform killer;
    public GameObject Killer;

    private void Start()
    {
        killer = GameObject.Find("Killer").transform;
    }

    public void killerTeleport() {
        if (InteractionObject.firstkey == 1)
        {
            killer.transform.position = target.transform.position;
        }
        else if (InteractionObject.firstkey == 11) {
            Killer.SetActive(false);
        }
    }

    public void killerTeleportOutside() {
        killer.transform.position = targetOutside.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            collision.transform.position = target.transform.position;
        }
    }
}
