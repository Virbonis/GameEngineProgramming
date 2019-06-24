using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_8 : MonoBehaviour
{
    public Transform[] Waypoints_8;
    public GameObject Waypoint8;
    public static bool Active8 = false;
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D room)
    {
        if (room.CompareTag("Killer"))
        {
            Waypoint8.SetActive(true);
            Active8 = true;
        }
    }
}
