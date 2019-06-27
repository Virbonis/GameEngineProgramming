using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor_7 : MonoBehaviour
{
    public Transform[] WaypointsCorridor_7;
    public GameObject Waypoint_7;
    public GameObject[] Waypoints;
    public static bool ActiveCorridor_7 = false;

    void Update()
    {
        if (Killer.patrol == false)
        {
            if (ActiveCorridor_7 == true)
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
            Waypoint_7.SetActive(true);
            ActiveCorridor_7 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
