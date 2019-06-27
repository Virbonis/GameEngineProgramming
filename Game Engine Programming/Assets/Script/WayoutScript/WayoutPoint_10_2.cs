using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_10_2 : MonoBehaviour
{
    public Transform[] Waypoints_10_2;
    public GameObject Waypoint10_2;
    public static bool Active10_2;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active10_2 == false)
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
            Waypoint10_2.SetActive(true);
            Active10_2 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
