using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalChase : MonoBehaviour
{
    public GameObject killer;
    public GameObject target;
    private Killer radius;
    private bool onSight;

    private void Start()
    {
        radius = GameObject.Find("Killer").GetComponent<Killer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            killer.SetActive(true);
            killer.transform.position = target.transform.position;
            gameObject.SetActive(false);
            radius.chaseRadius = 24f;
            Killer.onSight = true;
        }
    }
}
