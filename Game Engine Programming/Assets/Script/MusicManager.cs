using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    AudioSource myAudio;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = Resources.Load<AudioClip>("Menu Theme");
        Play();
    }

    private void Update()
    {
        if (SceneManagement.stopMusic == true)
        {
            if (myAudio.volume > 0)
            {
                myAudio.volume -= Time.deltaTime * 0.1f;
                Debug.Log(myAudio.volume);
            }
        }
        else {
            myAudio.volume += Time.deltaTime * 0.3f;
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
