using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorManager : MonoBehaviour
{
    public GameObject[] Waypoints;

    // Update is called once per frame
    void Update()
    {
        if (Killer.patrol == false)
        {
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(true);
            }
        }
        else
        {
            for (int x = 0; x < Waypoints.Length; x++)
            {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
