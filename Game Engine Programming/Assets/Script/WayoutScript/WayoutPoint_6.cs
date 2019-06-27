﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_6 : MonoBehaviour
{
    public Transform[] Waypoints_6;
    public GameObject Waypoint6;
    public static bool Active6;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active6 == false)
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
            Waypoint6.SetActive(true);
            Active6 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
