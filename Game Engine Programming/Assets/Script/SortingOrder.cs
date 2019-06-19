using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    private GameObject Player;
    private GameObject Killer;
    SpriteRenderer Object;

    void Start()
    {
        Player = GameObject.Find("Player");
        Killer = GameObject.Find("Killer");
        Object = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y > transform.position.y)
        {
            Object.sortingOrder = 1;
        }
        else {
            Object.sortingOrder = 0;
        }
    }
}
