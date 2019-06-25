using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_3 : MonoBehaviour
{
    public Transform[] Waypoints_3;
    public GameObject Waypoint3;
    public static bool Active3;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active3 == false)
        {
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D room)
    {
        if (room.CompareTag("Killer"))
        {
            Waypoint3.SetActive(true);
            Active3 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
