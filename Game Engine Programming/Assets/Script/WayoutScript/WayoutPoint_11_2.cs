using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_11_2 : MonoBehaviour
{
    public Transform[] Waypoints_11_2;
    public GameObject Waypoint11_2;
    public static bool Active11_2;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active11_2 == false)
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
            Waypoint11_2.SetActive(true);
            Active11_2 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
