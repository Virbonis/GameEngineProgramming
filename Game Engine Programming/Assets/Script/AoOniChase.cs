using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoOniChase : MonoBehaviour
{
    private AudioSource chase;
    private AudioClip chaseAoOni;
    private int counter = 0;
    AoOni speed;

    void Start()
    {
        chaseAoOni = Resources.Load<AudioClip>("Ao Oni Chase");
        chase = GetComponent<AudioSource>();
        speed = GameObject.Find("Ao Oni").GetComponent<AoOni>();
    }

    private void Update()
    {
        if (speed.moving == true && counter == 0) {
            chase.PlayOneShot(chaseAoOni);
            counter++;
        }
    }
}
