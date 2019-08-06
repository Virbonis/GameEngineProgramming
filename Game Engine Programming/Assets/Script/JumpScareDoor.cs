using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareDoor : MonoBehaviour
{
    public static AudioSource jumpscare;
    public static bool changeSuspense;

    void Start()
    {
        jumpscare = GetComponent<AudioSource>();
        changeSuspense = false;
        jumpscare.Play();
        jumpscare.volume = 0;
    }

    void Update()
    {
        if (jumpscare.volume < 1 && changeSuspense == false) {
            jumpscare.volume += Time.deltaTime * 0.2f;
        }
    }
}
