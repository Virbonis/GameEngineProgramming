using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject player;
    public GameObject killer;
    public GameObject blackScreen;
    public Image BlackScreen;
    private SceneManagement changeScene;

    private void Start()
    {
        changeScene = GameObject.FindWithTag("Scene Manager").GetComponent<SceneManagement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            blackScreen.SetActive(true);
            BlackScreen.canvasRenderer.SetAlpha(0.0f);
            player.SetActive(false);
            killer.SetActive(false);
            End();
        }
    }

    void End() {
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1f);
        BlackScreen.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(2f);
        SoundManager.PlaySound("Police Shoot");
        yield return new WaitForSeconds(5f);
        changeScene.Credit();
    }
}
