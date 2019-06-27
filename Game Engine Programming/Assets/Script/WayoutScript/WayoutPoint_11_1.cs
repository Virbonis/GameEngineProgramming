using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_11_1 : MonoBehaviour
{
    public Transform[] Waypoints_11_1;
    public GameObject Waypoint11_1;
    public static bool Active11_1;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active11_1 == false)
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
            Waypoint11_1.SetActive(true);
            Active11_1 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
