using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_10 : MonoBehaviour
{
    public Transform[] Waypoints_10;
    public GameObject Waypoint10;
    public static bool Active10;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active10 == false)
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
            Waypoint10.SetActive(true);
            Active10 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
