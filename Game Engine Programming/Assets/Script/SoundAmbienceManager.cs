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
        JumpScareDoor.changeSuspense = true;
    }

    void Update()
    {
        if (played == true)
        {
            played = false;
            audioSource.Play();
        }

        if (JumpScareDoor.changeSuspense == true) {
            JumpScareDoor.jumpscare.volume -= Time.deltaTime * 0.3f;
        }
    }
}
