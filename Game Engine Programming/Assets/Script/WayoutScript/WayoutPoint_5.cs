using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_5 : MonoBehaviour
{
    public Transform[] Waypoints_5;
    public GameObject Waypoint5;
    public static bool Active5;
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D room)
    {
        if (room.CompareTag("Killer"))
        {
            Waypoint5.SetActive(true);
            Active5 = true;
        }
    }
}
