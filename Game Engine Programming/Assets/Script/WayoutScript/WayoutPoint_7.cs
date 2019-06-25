using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_7 : MonoBehaviour
{
    public Transform[] Waypoints_7;
    public GameObject Waypoint7;
    public static bool Active7;
    public GameObject[] Waypoints;
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D room)
    {
        if (room.CompareTag("Killer"))
        {
            Waypoint7.SetActive(true);
            Active7 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
