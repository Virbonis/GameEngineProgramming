using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMusicManager_6 : MonoBehaviour
{

    public static AudioClip phase6;
    private AudioSource audioSource6;
    public GameObject player;
    public GameObject killer;
    private bool played6 = true;
    private float fadeOut = 0.8f;
    private float fadeIn = 0.8f;
    private bool fadeIncheck;

    void Start()
    {
        audioSource6 = GetComponent<AudioSource>();
        phase6 = Resources.Load<AudioClip>("Phase 6");
    }

    void Update()
    {
        var killer = GameObject.FindGameObjectWithTag("Killer").GetComponent<Killer>();

        if (ChaseMusicManager_4.timer >= 0 && Killer.onSight == true)
        {
            waitChangeAudio();
            Debug.Log(ChaseMusicManager_4.timer);
        }
        else if (ChaseMusicManager_4.timer < 0)
        {
            if (Vector3.Distance(player.transform.position, killer.transform.position) <= killer.TerrorRadius - 10 && played6 == true && Killer.onSight == true)
            {
                played6 = false;
                audioSource6.clip = phase6;
                audioSource6.Play();
                fadeIncheck = true;
                Debug.Log("Change");
            }
            else if (Vector3.Distance(player.transform.position, killer.transform.position) >= killer.TerrorRadius - 10 || Killer.onSight == false)
            {
                fadeIncheck = false;
                played6 = true;
            }
        }

        if (fadeIncheck == true)
        {
            if (audioSource6.volume <= 0.8f)
            {
                audioSource6.volume += Time.deltaTime * fadeIn;
            }
        }
        else
        {
            audioSource6.volume -= Time.deltaTime * fadeOut;
        }
    }

    void waitChangeAudio()
    {
        ChaseMusicManager_4.timer -= Time.deltaTime;
    }
}
