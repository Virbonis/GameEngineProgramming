using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_8 : MonoBehaviour
{
    public Transform[] Waypoints_8;
    public GameObject Waypoint8;
    public static bool Active8 = false;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active8 == false)
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
            Waypoint8.SetActive(true);
            Active8 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
