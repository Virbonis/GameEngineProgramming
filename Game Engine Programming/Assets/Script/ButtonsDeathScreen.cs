using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsDeathScreen : MonoBehaviour
{

    public Image retry;
    public Image quit;

    void Start()
    {
        retry.canvasRenderer.SetAlpha(0.0f);
        quit.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(7f);
        retry.CrossFadeAlpha(1, 0.5f, false);
        quit.CrossFadeAlpha(1, 0.5f, false);
    }
}
