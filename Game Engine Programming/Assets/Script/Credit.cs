using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credit : MonoBehaviour
{
    public Text youSurvived;
    public Text Thanks;
    private SceneManagement changeScene;
    public GameObject credit;

    void Start()
    {
        youSurvived.canvasRenderer.SetAlpha(0.0f);
        Thanks.canvasRenderer.SetAlpha(0.0f);
        changeScene = GameObject.FindWithTag("Scene Manager").GetComponent<SceneManagement>();
        credit.SetActive(false);
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(5.5f);
        youSurvived.CrossFadeAlpha(1f, 4f, false);
        yield return new WaitForSeconds(8f);
        youSurvived.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(2f);
        Thanks.CrossFadeAlpha(1f, 5f, false);
        yield return new WaitForSeconds(7f);
        Thanks.CrossFadeAlpha(0f, 3f, false);
        yield return new WaitForSeconds(4.5f);
        credit.SetActive(true);
        yield return new WaitForSeconds(86f);
        changeScene.MenuScreen();
    }
}
