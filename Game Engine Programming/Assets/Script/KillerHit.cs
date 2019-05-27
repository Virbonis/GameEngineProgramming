using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerHit : MonoBehaviour
{
    public static bool hit;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            hit = true;
            Debug.Log("The player got hit");
        }
    }
}
