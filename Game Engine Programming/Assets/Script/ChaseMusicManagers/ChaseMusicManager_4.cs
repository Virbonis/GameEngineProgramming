using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMusicManager_4 : MonoBehaviour
{

    public static AudioClip phase4;
    private AudioSource audioSource4;
    public GameObject player;
    public GameObject killer;
    private bool played4 = true;
    private float fadeOut = 0.5f;
    private float fadeIn = 0.4f;
    private bool fadeIncheck;
    public static float timer = 5f;

    void Start()
    {
        audioSource4 = GetComponent<AudioSource>();
        phase4 = Resources.Load<AudioClip>("Phase 4");
    }

    void Update()
    {
        var killer = GameObject.FindGameObjectWithTag("Killer").GetComponent<Killer>();

        if (timer >= 0 && Killer.onSight == true)
        {
            waitChangeAudio();
        }
        else if (timer < 0)
        {
            if (Vector3.Distance(player.transform.position, killer.transform.position) >= killer.TerrorRadius - 6 && played4 == true && 
            Killer.onSight == true)
            {
                played4 = false;
                audioSource4.clip = phase4;
                audioSource4.Play();
                fadeIncheck = true;
            }
            else if (Vector3.Distance(player.transform.position, killer.transform.position) <= killer.TerrorRadius - 6 || Killer.onSight == false)
            {
                fadeIncheck = false;
                played4 = true;
            }
        }

        if (fadeIncheck == true)
        {
            if (audioSource4.volume <= 0.6f)
            {
                audioSource4.volume += Time.deltaTime * fadeIn;
            }
        }
        else if (fadeIncheck == false || Killer.onSight == false)
        {
            audioSource4.volume -= Time.deltaTime * fadeOut;
        }
    }

    void waitChangeAudio() {
        timer -= Time.deltaTime;
    }
}
