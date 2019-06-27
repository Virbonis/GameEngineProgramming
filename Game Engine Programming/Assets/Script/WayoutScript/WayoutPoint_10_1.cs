using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_10_1 : MonoBehaviour
{
    public Transform[] Waypoints_10_1;
    public GameObject Waypoint10_1;
    public static bool Active10_1;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active10_1 == false)
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
            Waypoint10_1.SetActive(true);
            Active10_1 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
