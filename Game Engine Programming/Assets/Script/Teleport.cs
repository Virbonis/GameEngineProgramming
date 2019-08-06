using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject target;
    public GameObject targetOutside;
    private Transform killer;
    public GameObject[] DeactivateObjects;
    public GameObject[] ActivateObjects;

    private void Start()
    {
        killer = GameObject.Find("Killer").transform;
    }

    public void killerTeleport() {
        killer.transform.position = target.transform.position;
    }

    public void SetActiveObject() {
        for (int x = 0; x < DeactivateObjects.Length; x++) {
            DeactivateObjects[x].SetActive(false);
        }

        for (int x = 0; x < ActivateObjects.Length; x++)
        {
            ActivateObjects[x].SetActive(true);
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
