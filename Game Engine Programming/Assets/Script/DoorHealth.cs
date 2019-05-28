using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHealth : MonoBehaviour
{
    public int doorHealth = 3;

    void Update()
    {
        if (doorHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
