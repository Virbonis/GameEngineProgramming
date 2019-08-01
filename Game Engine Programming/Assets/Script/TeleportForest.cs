using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportForest : MonoBehaviour
{
    public GameObject BlackScreen;
    public Image blackScreen;
    public GameObject target;
    public GameObject player;
    public GameObject[] sounds;
    public GameObject forestAmbience;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            BlackScreen.SetActive(true);
            blackScreen.canvasRenderer.SetAlpha(0.0f);
            Teleport();
        }
    }

    void Teleport() {
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        blackScreen.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(2f);
        for (int x = 0; x < sounds.Length; x++) {
            sounds[x].SetActive(false);
        }
        forestAmbience.SetActive(true);
        player.transform.position = target.transform.position;
        yield return new WaitForSeconds(1f);
        blackScreen.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        BlackScreen.SetActive(false);
    }
}
