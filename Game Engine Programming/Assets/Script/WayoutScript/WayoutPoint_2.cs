using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_2 : MonoBehaviour
{
    public Transform[] Waypoints_2;
    public GameObject Waypoint2;
    public static bool Active2 = false;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active2 == false)
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
            Waypoint2.SetActive(true);
            Active2 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
