using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMusicManager : MonoBehaviour
{

    public static AudioClip phase1;
    private AudioSource audioSource;
    public GameObject player;
    public GameObject killer;
    private bool played1 = true;
    private float fadeOut = 0.2f;
    private float fadeIn = 0.1f;
    private bool fadeIncheck;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        phase1 = Resources.Load<AudioClip>("Phase 1");
    }

    void Update()
    {
        var killer = GameObject.FindGameObjectWithTag("Killer").GetComponent<Killer>();
        if (Vector3.Distance(player.transform.position, killer.transform.position) <= killer.TerrorRadius &&
            Vector3.Distance(player.transform.position, killer.transform.position) >= killer.TerrorRadius - 6 && played1 == true && Killer.onSight == false)
        {
            played1 = false;
            audioSource.clip = phase1;
            audioSource.Play();
            fadeIncheck = true;
        }
        else if(Vector3.Distance(player.transform.position, killer.transform.position) >= killer.TerrorRadius ||
            Vector3.Distance(player.transform.position, killer.transform.position) <= killer.TerrorRadius - 6 || Killer.onSight == true)
        {
            fadeIncheck = false;
            played1 = true;
        }

        if (fadeIncheck == true)
        {
            if (audioSource.volume <= 0.2f)
            {
                audioSource.volume += Time.deltaTime * fadeIn;
            }
        }
        else {
            audioSource.volume -= Time.deltaTime * fadeOut;
        }
    }
}
