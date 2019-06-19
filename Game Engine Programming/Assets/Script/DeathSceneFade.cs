using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathSceneFade : MonoBehaviour
{
    public Image splashImage;
    public GameObject[] soundMute;
    public static bool DeathFont;
    private float timer = 2.15f;

    void Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);
    }

    private void Update()
    {
        if (Player.DeathScene == true) {
            StartCoroutine(Wait());
            DeathFont = true;
            Player.DeathScene = false;
        }
    }

    public void FadeIn() {
        splashImage.CrossFadeAlpha(1, 1f, false);
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(timer);
        SoundManager.PlaySound("You Are Dead");
        for (int x = 0; x < 3; x++) {
            soundMute[x].SetActive(false);
        }
        FadeIn();
    }
}
