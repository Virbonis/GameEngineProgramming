using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Disclaimer : MonoBehaviour
{
    public Text UIDisclaimer;
    public Text UIHeadphone;
    private SceneManagement changeScene;

    void Start()
    {
        UIHeadphone.canvasRenderer.SetAlpha(0.0f);
        UIDisclaimer.canvasRenderer.SetAlpha(0.0f);
        changeScene = GameObject.FindWithTag("Scene Manager").GetComponent<SceneManagement>();
        DisplayText();
    }

    void DisplayText() {
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(6f);
        UIHeadphone.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(5f);
        UIHeadphone.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(2f);
        UIDisclaimer.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(5f);
        UIDisclaimer.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(3f);
        changeScene.MenuScreen();
    }
}
