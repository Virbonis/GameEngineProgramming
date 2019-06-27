using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint : MonoBehaviour
{
    public Transform[] Waypoints1;
    public GameObject Waypoint;
    public GameObject[] Waypoints;
    public static bool Active;
    void Update()
    {
        if (Active == false)
        {
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D room)
    {
        if (room.CompareTag("Killer")) {
            Waypoint.SetActive(true);
            Active = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }   
    }
}
