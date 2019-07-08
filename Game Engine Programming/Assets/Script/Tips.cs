using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tips : MonoBehaviour
{
    public Image Loading;
    public Text tips1;
    public Text tips2;
    public Text tips3;
    public Text tips4;
    
    void Start()
    {
        tips1.canvasRenderer.SetAlpha(0.0f);
        tips2.canvasRenderer.SetAlpha(0.0f);
        tips3.canvasRenderer.SetAlpha(0.0f);
        tips4.canvasRenderer.SetAlpha(0.0f);
        TipsDisplay();
    }

    void TipsDisplay() {
        int random = Random.Range(1, 5);
        if (random == 1)
        {
            StartCoroutine(Wait_1());
        }
        else if (random == 2)
        {
            StartCoroutine(Wait_2());
        }
        else if (random == 3)
        {
            StartCoroutine(Wait_3());
        }
        else if (random == 4) {
            StartCoroutine(Wait_4());
        }
    }

    IEnumerator Wait_1() {
        yield return new WaitForSeconds(3f);
        tips1.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(4f);
        tips1.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        Loading.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Wait());
    }

    IEnumerator Wait_2()
    {
        yield return new WaitForSeconds(3f);
        tips2.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(4f);
        tips2.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        Loading.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Wait());
    }

    IEnumerator Wait_3()
    {
        yield return new WaitForSeconds(3f);
        tips3.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(4f);
        tips3.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        Loading.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Wait());
    }

    IEnumerator Wait_4()
    {
        yield return new WaitForSeconds(3f);
        tips4.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(4f);
        tips4.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        Loading.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Gameplay");
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
