using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static AudioSource myAudio;
    public static bool played;
    private bool musicPlayed = true;
    private float timer;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = Resources.Load<AudioClip>("Menu Theme");
        myAudio.volume = SettingsMenu.currVolume;
        timer = 3f;
        played = false;
    }

    private void Update()
    {
        if (SceneManagement.stopMusic == true && played == true)
        {
            if (myAudio.volume > 0)
            {
                myAudio.volume -= Time.deltaTime * 0.05f;
                Debug.Log(myAudio.volume);
            }
            else {
                myAudio.Stop();
                musicPlayed = true;
                timer = 3f;
                Debug.Log("Stop Playing");
            }
        }
        else if (SceneManagement.stopMusic == false && played == false && musicPlayed == true) {
            if (musicPlayed) {
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else {
                    myAudio.Play();
                    musicPlayed = false;
                }
            }
            myAudio.volume += Time.deltaTime * 0.5f;
        }
    }

    void Play() {
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(3f);
        myAudio.Play();
    }
}
