using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_9_2 : MonoBehaviour
{
    public Transform[] Waypoints_9_2;
    public GameObject Waypoint9_2;
    public static bool Active9_2 = false;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active9_2 == false)
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
            Waypoint9_2.SetActive(true);
            Active9_2 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
