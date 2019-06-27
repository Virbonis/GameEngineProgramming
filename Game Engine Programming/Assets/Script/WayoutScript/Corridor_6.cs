using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor_6 : MonoBehaviour
{
    public Transform[] WaypointsCorridor_6;
    public GameObject Waypoint_6;
    public GameObject[] Waypoints;
    public static bool ActiveCorridor_6 = false;

    void Update()
    {
        if (Killer.patrol == false)
        {
            if (ActiveCorridor_6 == true)
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
            Waypoint_6.SetActive(true);
            ActiveCorridor_6 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
