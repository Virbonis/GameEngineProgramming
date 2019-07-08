using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credit : MonoBehaviour
{
    public Text youSurvived;
    private SceneManagement changeScene;

    void Start()
    {
        youSurvived.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(Wait());
        changeScene = GameObject.FindWithTag("Scene Manager").GetComponent<SceneManagement>();
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(0.1f);
        youSurvived.CrossFadeAlpha(1f, 2f, false);
        yield return new WaitForSeconds(5f);
        youSurvived.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(2f);
        changeScene.MenuScreen();
    }
}
