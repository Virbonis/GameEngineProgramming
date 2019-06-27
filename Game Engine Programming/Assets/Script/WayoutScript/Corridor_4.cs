using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor_4 : MonoBehaviour
{
    public Transform[] WaypointsCorridor_4;
    public GameObject Waypoint_4;
    public GameObject[] Waypoints;
    public static bool ActiveCorridor_4 = false;

    void Update()
    {
        if (Killer.patrol == false)
        {
            if (ActiveCorridor_4 == true)
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
            Waypoint_4.SetActive(true);
            ActiveCorridor_4 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
