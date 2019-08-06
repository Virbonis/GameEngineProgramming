using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspenseTrapRoom : MonoBehaviour
{
    private AudioSource suspense2;
    private bool changeSuspense;

    private void Start()
    {
        suspense2 = GetComponent<AudioSource>();
        suspense2.Play();
        suspense2.volume = 0;
        JumpScareDoor.changeSuspense = true;
    }

    void Update()
    {
        if (suspense2.volume < 1) {
            suspense2.volume += Time.deltaTime * 0.3f;
        }

        if (JumpScareDoor.changeSuspense) {
            JumpScareDoor.jumpscare.volume -= Time.deltaTime * 0.2f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            changeSuspense = true;
            gameObject.SetActive(false);
        }
    }
}
