using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_4 : MonoBehaviour
{
    public Transform[] Waypoints_4;
    public GameObject Waypoint4;
    public static bool Active4;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active4 == false)
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
            Waypoint4.SetActive(true);
            Active4 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
