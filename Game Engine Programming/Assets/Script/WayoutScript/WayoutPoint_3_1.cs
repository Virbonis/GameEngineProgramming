using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_3_1 : MonoBehaviour
{
    public Transform[] Waypoints_3_1;
    public GameObject Waypoint3_1;
    public static bool Active3_1;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active3_1 == false)
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
            Waypoint3_1.SetActive(true);
            Active3_1 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
