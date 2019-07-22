using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    private AudioSource jumpscare;
    private AudioClip jumpScareClip;

    void Start()
    {
        jumpScareClip = Resources.Load<AudioClip>("JumpScare Pictures");
        jumpscare = GetComponent<AudioSource>();
        jumpscare.PlayOneShot(jumpScareClip);
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(7f);
        Application.Quit();
        Debug.Log("Exit");
    }
}
