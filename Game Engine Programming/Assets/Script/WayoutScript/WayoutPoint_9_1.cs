using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint_9_1 : MonoBehaviour
{
    public Transform[] Waypoints_9_1;
    public GameObject Waypoint9_1;
    public static bool Active9_1;
    public GameObject way;
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D room)
    {
        if (room.CompareTag("Killer"))
        {
            Waypoint9_1.SetActive(true);
            Active9_1 = true;
            way.SetActive(false);
        }
    }
}
