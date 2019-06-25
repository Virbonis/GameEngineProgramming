using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_6 : MonoBehaviour
{
    public Transform[] Waypoints_6;
    public GameObject Waypoint6;
    public static bool Active6;
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D room)
    {
        if (room.CompareTag("Killer"))
        {
            Waypoint6.SetActive(true);
            Active6 = true;
        }
    }
}
