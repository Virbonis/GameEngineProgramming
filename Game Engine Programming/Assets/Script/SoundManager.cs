﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip EvilWithin2, EvilWithin3, playerBlood, death, pickupKey,
        openDoor, closeDoor, lockedDoor, unlockDoor, pickUpMedicine, Healing, notePickup, gainKnowledge, ponder,
        police, dropItem;
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
        Healing = Resources.Load<AudioClip>("Healing");
        notePickup = Resources.Load<AudioClip>("Note Pickup");
        gainKnowledge = Resources.Load<AudioClip>("Gain Knowledge");
        ponder = Resources.Load<AudioClip>("Ponder");
        police = Resources.Load<AudioClip>("Police Shoot");
        dropItem = Resources.Load<AudioClip>("Drop Item");
        audioSource = GetComponent<AudioSource>();
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
            case "Healing":
                audioSource.PlayOneShot(Healing);
                break;
            case "Note Pickup":
                audioSource.PlayOneShot(notePickup);
                break;
            case "Gain Knowledge":
                audioSource.PlayOneShot(gainKnowledge);
                break;
            case "Ponder":
                audioSource.PlayOneShot(ponder);
                break;
            case "Police Shoot":
                audioSource.PlayOneShot(police);
                break;
            case "Drop Item":
                audioSource.PlayOneShot(dropItem);
                break;
        }
    }
}
