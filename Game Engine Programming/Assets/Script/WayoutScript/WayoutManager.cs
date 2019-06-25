using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutManager : MonoBehaviour
{
    public GameObject[] Waypoints;
    void Update()
    {
        if (WayoutPoint_9.Active9 == true)
        {
            for (int x = 0; x < Waypoints.Length; x++) {
                Waypoints[x].SetActive(false);
            }
        }
    }
}
