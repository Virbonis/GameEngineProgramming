using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_9_1 : MonoBehaviour
{
    public Transform[] Waypoints_9_1;
    public GameObject Waypoint9_1;
    public static bool Active9_1;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active9_1 == false)
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
            Waypoint9_1.SetActive(true);
            Active9_1 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
