using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    private AudioSource jumpscare;
    private AudioClip jumpScareClip;
    public GameObject[] deactivateSound;

    void Start()
    {
        jumpScareClip = Resources.Load<AudioClip>("JumpScare Pictures");
        jumpscare = GetComponent<AudioSource>();
        jumpscare.PlayOneShot(jumpScareClip);
        for (int x = 0; x < deactivateSound.Length; x++) {
            deactivateSound[x].SetActive(false);
        }
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(7f);
        Application.Quit();
        Debug.Log("Exit");
    }
}
