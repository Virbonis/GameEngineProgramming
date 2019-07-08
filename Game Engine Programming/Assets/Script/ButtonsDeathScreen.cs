using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsDeathScreen : MonoBehaviour
{
    public Image retry;
    public Image quit;
    public GameObject retryObject;
    public GameObject quitObject;
    public Button retryButton;

    void Start()
    {
        retry.canvasRenderer.SetAlpha(0.0f);
        quit.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(7f);
        retryObject.SetActive(true);
        quitObject.SetActive(true);
        retry.CrossFadeAlpha(1, 0.5f, false);
        quit.CrossFadeAlpha(1, 0.5f, false);
    }
}
