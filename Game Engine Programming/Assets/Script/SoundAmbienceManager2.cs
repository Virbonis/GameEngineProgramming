using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAmbienceManager2 : MonoBehaviour
{

    public static AudioClip Ambience;
    private AudioSource audioSource;
    private bool played = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Ambience = Resources.Load<AudioClip>("Empty Ambience");
    }

    void Update()
    {
        if (played == true)
        {
            played = false;
            audioSource.clip = Ambience;
            audioSource.Play();
        }
    }
}
