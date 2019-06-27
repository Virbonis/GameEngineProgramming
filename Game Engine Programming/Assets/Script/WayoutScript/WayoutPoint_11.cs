using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_11 : MonoBehaviour
{
    public Transform[] Waypoints_11;
    public GameObject Waypoint11;
    public static bool Active11;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active11 == false)
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
            Waypoint11.SetActive(true);
            Active11 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
