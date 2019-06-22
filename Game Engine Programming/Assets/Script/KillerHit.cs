﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerHit : MonoBehaviour
{
    public static bool hit;
    public static bool blood;
    private int number;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            hit = true;
            blood = true;
            other.gameObject.SendMessage("TakeDamage");
            SoundManager.PlaySound("Blood Sounfeffect");
            number = Random.Range(1, 5);
            if (number == 1)
            {
                KillerSound.PlaySoundEnemy("Laughing 1");
            }
            else if (number == 2) {
                KillerSound.PlaySoundEnemy("Laughing 2");
            }
            else if (number == 3)
            {
                KillerSound.PlaySoundEnemy("Laughing 3");
            }
            else if (number == 4)
            {
                KillerSound.PlaySoundEnemy("Laughing 4");
            }
        }
    }
}
