using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint : MonoBehaviour
{
    public Transform[] Waypoints;
    public GameObject Waypoint;
    public static bool Active = false;
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D room)
    {
        if (room.CompareTag("Killer")) {
            Waypoint.SetActive(true);
            Active = true;
        }   
    }
}
