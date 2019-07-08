using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Disclaimer : MonoBehaviour
{
    public Text UI;
    private SceneManagement changeScene;

    void Start()
    {
        UI.canvasRenderer.SetAlpha(0.0f);
        changeScene = GameObject.FindWithTag("Scene Manager").GetComponent<SceneManagement>();
        DisplayText();
    }

    void DisplayText() {
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(6f);
        UI.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(5f);
        UI.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(3f);
        changeScene.MenuScreen();
    }
}
