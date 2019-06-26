using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor_2 : MonoBehaviour
{
    public Transform[] WaypointsCorridor_2;
    public GameObject Waypoint_2;
    public GameObject[] Waypoints;
    public static bool ActiveCorridor_2 = false;

    void Update()
    {
        if (Killer.patrol == false)
        {
            if (ActiveCorridor_2 == true)
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
            Waypoint_2.SetActive(true);
            ActiveCorridor_2 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
