using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerHit : MonoBehaviour
{
    public static bool hit;
    private int number;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            hit = true;
            SoundManager.PlaySound("Blood Sounfeffect");
            Health.health -= 1;
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
