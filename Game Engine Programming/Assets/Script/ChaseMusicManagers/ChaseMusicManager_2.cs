using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMusicManager_2 : MonoBehaviour
{

    public static AudioClip phase2;
    private AudioSource audioSource2;
    public GameObject player;
    public GameObject killer;
    private bool played2 = true;
    private float fadeOut = 0.4f;
    private float fadeIn = 0.3f;
    private bool fadeIncheck;

    void Start()
    {
        audioSource2 = GetComponent<AudioSource>();
        phase2 = Resources.Load<AudioClip>("Phase 2");
    }

    void Update()
    {
        var killer = GameObject.FindGameObjectWithTag("Killer").GetComponent<Killer>();

        if (Vector3.Distance(player.transform.position, killer.transform.position) <= killer.TerrorRadius - 6 &&
            Vector3.Distance(player.transform.position, killer.transform.position) >= killer.TerrorRadius - 10 && played2 == true && Killer.onSight == false)
        {
            played2 = false;
            audioSource2.clip = phase2;
            audioSource2.Play();
            fadeIncheck = true;
            Debug.Log("Change");
        }
        else if (Vector3.Distance(player.transform.position, killer.transform.position) >= killer.TerrorRadius - 6 ||
                Vector3.Distance(player.transform.position, killer.transform.position) <= killer.TerrorRadius - 10 || Killer.onSight == true)
        {
            fadeIncheck = false;
            played2 = true;
        }

        if (fadeIncheck == true)
        {
            if (audioSource2.volume <= 0.4f)
            {
                audioSource2.volume += Time.deltaTime * fadeIn;
            }
        }
        else
        {
            audioSource2.volume -= Time.deltaTime * fadeOut;
        }
    }
}
