using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMusicManager_3 : MonoBehaviour
{

    public static AudioClip phase3;
    private AudioSource audioSource3;
    public GameObject player;
    public GameObject killer;
    private bool played3 = true;
    private float fadeOut = 0.6f;
    private float fadeIn = 0.4f;
    private bool fadeIncheck;

    void Start()
    {
        audioSource3 = GetComponent<AudioSource>();
        phase3 = Resources.Load<AudioClip>("Phase 3");
    }

    void Update()
    {
        var killer = GameObject.FindGameObjectWithTag("Killer").GetComponent<Killer>();

        if (Vector3.Distance(player.transform.position, killer.transform.position) <= killer.TerrorRadius - 10 && played3 == true && Killer.onSight == false)
        {
            played3 = false;
            audioSource3.clip = phase3;
            audioSource3.Play();
            fadeIncheck = true;
            Debug.Log("Change");
        }
        else if (Vector3.Distance(player.transform.position, killer.transform.position) >= killer.TerrorRadius - 10 || Killer.onSight == true)
        {
            fadeIncheck = false;
            played3 = true;
        }

        if (fadeIncheck == true)
        {
            if (audioSource3.volume <= 0.6f)
            {
                audioSource3.volume += Time.deltaTime * fadeIn;
            }
        }
        else
        {
            audioSource3.volume -= Time.deltaTime * fadeOut;
        }
    }
}
