using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    public static AudioClip leftFootstep, rightFootstep;
    static AudioSource audioSource;

    void Start()
    {
        leftFootstep = Resources.Load<AudioClip>("Left Footstep");
        rightFootstep = Resources.Load<AudioClip>("Right Footstep");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Left Footstep":
                audioSource.PlayOneShot(leftFootstep);
                break;
            case "Right Footstep":
                audioSource.PlayOneShot(rightFootstep);
                break;
        }
    }
}
