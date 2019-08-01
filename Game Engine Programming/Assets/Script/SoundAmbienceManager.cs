using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAmbienceManager : MonoBehaviour
{
    private AudioSource audioSource;
    private bool played = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (played == true)
        {
            played = false;
            audioSource.Play();
        }
    }
}
