using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateCharlie : MonoBehaviour
{
    public GameObject player;
    public GameObject scaryImage;
    public GameObject AoOni;

    public void TeleportPlayer() {
        scaryImage.SetActive(true);
        player.SetActive(false);
        AoOni.SetActive(false);
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(0.2f);
        scaryImage.SetActive(false);
        player.SetActive(true);
    }
}
