using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_9 : MonoBehaviour
{
    public Transform[] Waypoints_9;
    public GameObject Waypoint9;
    public static bool Active9 = false;
    public GameObject[] Waypoints;
    void Update()
    {
        if (Active9 == false)
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
            Debug.Log("true");
            Waypoint9.SetActive(true);
            Active9 = true;
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
