using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayoutPoint : MonoBehaviour
{
    public Transform[] Waypoints;
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D room)
    {
        if (room.CompareTag("Killer")) {
            print("Please, FUCK MY ASS");
        }   
    }
}
