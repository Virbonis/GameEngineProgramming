﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor_8 : MonoBehaviour
{
    public Transform[] WaypointsCorridor_8;
    public GameObject Waypoint_8;
    public GameObject[] Waypoints;
    public static bool ActiveCorridor_8 = false;

    void Update()
    {
        if (Killer.patrol == false)
        {
            if (ActiveCorridor_8 == true)
            {
                for (int x = 0; x < Waypoints.Length; x++)
                {
                    Waypoints[x].SetActive(false);
                }
            }
        }
        else
        {
            gameObject.SetActive(false);
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D room)
    {
        if (room.CompareTag("Killer"))
        {
            Waypoint_8.SetActive(true);
            ActiveCorridor_8 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}