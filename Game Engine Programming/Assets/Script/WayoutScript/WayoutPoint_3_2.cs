using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_3_2 : MonoBehaviour
{
    public Transform[] Waypoints_3_2;
    public GameObject Waypoint3_2;
    public static bool Active3_2;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active3_2 == false)
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
            Waypoint3_2.SetActive(true);
            Active3_2 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
