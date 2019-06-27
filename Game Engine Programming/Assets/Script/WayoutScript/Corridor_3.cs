using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor_3 : MonoBehaviour
{
    public Transform[] WaypointsCorridor_3;
    public GameObject Waypoint_3;
    public GameObject[] Waypoints;
    public static bool ActiveCorridor_3 = false;

    void Update()
    {
        if (Killer.patrol == false)
        {
            if (ActiveCorridor_3 == true)
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
            Waypoint_3.SetActive(true);
            ActiveCorridor_3 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
