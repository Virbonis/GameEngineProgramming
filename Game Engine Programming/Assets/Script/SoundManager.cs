using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip EvilWithin2, EvilWithin3;
    static AudioSource audioSource;

    void Start()
    {
        EvilWithin2 = Resources.Load<AudioClip>("Evil2");
        EvilWithin3 = Resources.Load<AudioClip>("Evil3");

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
        }
    }
}
