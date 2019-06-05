using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_2 : MonoBehaviour
{
    public Transform[] Waypoints_2;
    public GameObject Waypoint2;
    public static bool Active2 = false;
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D room)
    {
        if (room.CompareTag("Killer"))
        {
            Waypoint2.SetActive(true);
            Active2 = true;
        }
    }
}
