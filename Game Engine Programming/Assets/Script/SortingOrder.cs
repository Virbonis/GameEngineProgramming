using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    private GameObject Killer;
    SpriteRenderer Object;

    void Start()
    {
        Killer = GameObject.Find("Killer");
        Object = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Killer.transform.position.y > transform.position.y)
        {
            Object.sortingOrder = 500;
        }
        else
        {
            Object.sortingOrder = 498;
        }
    }
}
