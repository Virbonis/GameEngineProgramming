using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor_1 : MonoBehaviour
{
    public Transform[] WaypointsCorridor;
    public GameObject Waypoint;
    public GameObject[] Waypoints;
    public static bool ActiveCorridor = false;
    void Update()
    {
        if (ActiveCorridor == true) {
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
            Waypoint.SetActive(true);
            ActiveCorridor = true;
            for (int x = 0; x < Waypoints.Length; x++) {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
