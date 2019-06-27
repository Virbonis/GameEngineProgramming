using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor_5 : MonoBehaviour
{
    public Transform[] WaypointsCorridor_5;
    public GameObject Waypoint_5;
    public GameObject[] Waypoints;
    public static bool ActiveCorridor_5 = false;

    void Update()
    {
        if (Killer.patrol == false)
        {
            if (ActiveCorridor_5 == true)
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
            Waypoint_5.SetActive(true);
            ActiveCorridor_5 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
