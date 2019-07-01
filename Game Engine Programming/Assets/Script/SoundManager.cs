﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip EvilWithin2, EvilWithin3, playerBlood, death, pickupKey, openDoor, closeDoor, lockedDoor, unlockDoor, pickUpMedicine;
    static AudioSource audioSource;

    void Start()
    {
        EvilWithin2 = Resources.Load<AudioClip>("Evil2");
        EvilWithin3 = Resources.Load<AudioClip>("Evil3");
        playerBlood = Resources.Load<AudioClip>("Blood Sounfeffect");
        death = Resources.Load<AudioClip>("You Are Dead");
        pickupKey = Resources.Load<AudioClip>("Pickup Key");
        openDoor = Resources.Load<AudioClip>("Open Door");
        closeDoor = Resources.Load<AudioClip>("Close Door");
        lockedDoor = Resources.Load<AudioClip>("Locked Door");
        unlockDoor = Resources.Load<AudioClip>("Unlock");
        pickUpMedicine = Resources.Load<AudioClip>("Bottle Pickup");
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public static void PlaySound(string clip) {
        switch (clip) {
            case "Evil2":
                audioSource.PlayOneShot(EvilWithin2);
                break;
            case "Evil3":
                audioSource.PlayOneShot(EvilWithin3);
                break;
            case "Blood Sounfeffect":
                audioSource.PlayOneShot(playerBlood);
                break;
            case "You Are Dead":
                audioSource.PlayOneShot(death);
                break;
            case "Pickup Key":
                audioSource.PlayOneShot(pickupKey);
                break;
            case "Open Door":
                audioSource.PlayOneShot(openDoor);
                break;
            case "Close Door":
                audioSource.PlayOneShot(closeDoor);
                break;
            case "Locked Door":
                audioSource.PlayOneShot(lockedDoor);
                break;
            case "Unlock":
                audioSource.PlayOneShot(unlockDoor);
                break;
            case "Medicine Pickup":
                audioSource.PlayOneShot(pickUpMedicine);
                break;
        }
    }
}
