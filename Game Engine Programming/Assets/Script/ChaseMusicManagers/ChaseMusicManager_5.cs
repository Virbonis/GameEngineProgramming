using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMusicManager_5 : MonoBehaviour
{

    public static AudioClip phase5;
    private AudioSource audioSource5;
    public GameObject player;
    public GameObject killer;
    private bool played5 = true;
    private float fadeOut = 0.6f;
    private float fadeIn = 0.3f;
    private bool fadeIncheck;

    void Start()
    {
        audioSource5 = GetComponent<AudioSource>();
        phase5 = Resources.Load<AudioClip>("Phase 5");
    }

    void Update()
    {
        var killer = GameObject.FindGameObjectWithTag("Killer").GetComponent<Killer>();

        if (ChaseMusicManager_4.timer >= 0 && Killer.onSight == true)
        {
            waitChangeAudio();
        }
        else if (ChaseMusicManager_4.timer < 0)
        {
            if (Vector3.Distance(player.transform.position, killer.transform.position) <= killer.TerrorRadius - 6 &&
                Vector3.Distance(player.transform.position, killer.transform.position) >= killer.TerrorRadius - 10 && played5 == true && Killer.onSight == true)
            {
                played5 = false;
                audioSource5.clip = phase5;
                audioSource5.Play();
                fadeIncheck = true;
                Debug.Log("Change");
            }
            else if (Vector3.Distance(player.transform.position, killer.transform.position) >= killer.TerrorRadius - 6 ||
                    Vector3.Distance(player.transform.position, killer.transform.position) <= killer.TerrorRadius - 10 || Killer.onSight == false)
            {
                fadeIncheck = false;
                played5 = true;
            }
        }

        if (fadeIncheck == true)
        {
            if (audioSource5.volume <= 0.6f)
            {
                audioSource5.volume += Time.deltaTime * fadeIn;
            }
        }
        else
        {
            audioSource5.volume -= Time.deltaTime * fadeOut;
        }
    }

    void waitChangeAudio()
    {
        ChaseMusicManager_4.timer -= Time.deltaTime;
    }
}
