using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerSound : MonoBehaviour
{
    public static AudioClip Laughing1, Laughing2, Laughing3, Laughing4, knifeSoundEffect;
    static AudioSource audioSourceEnemy;

    void Start()
    {
        Laughing1 = Resources.Load<AudioClip>("Laughing 1");
        Laughing2 = Resources.Load<AudioClip>("Laughing 2");
        Laughing3 = Resources.Load<AudioClip>("Laughing 3");
        Laughing4 = Resources.Load<AudioClip>("Laughing 4");
        knifeSoundEffect = Resources.Load<AudioClip>("Knife Sound Effect");

        audioSourceEnemy = GetComponent<AudioSource>();
    }

    public static void PlaySoundEnemy(string clip)
    {
        switch (clip)
        {
            case "Laughing 1":
                audioSourceEnemy.PlayOneShot(Laughing1);
                break;
            case "Laughing 2":
                audioSourceEnemy.PlayOneShot(Laughing2);
                break;
            case "Laughing 3":
                audioSourceEnemy.PlayOneShot(Laughing3);
                break;
            case "Laughing 4":
                audioSourceEnemy.PlayOneShot(Laughing4);
                break;
            case "Knife Sound Effect":
                audioSourceEnemy.PlayOneShot(knifeSoundEffect);
                break;
        }
    }
}
