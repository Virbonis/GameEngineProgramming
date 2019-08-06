using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoader : MonoBehaviour
{
    public Image Wire;
    public Image WhiteVision;
    public GameObject white;
    public Text TheNight;
    public Text hearing;
    public Text getout;

    private void Start()
    {
        TheNight.canvasRenderer.SetAlpha(0.0f);
        hearing.canvasRenderer.SetAlpha(0.0f);
        getout.canvasRenderer.SetAlpha(0.0f);
        LoadLevel();
    }

    public void LoadLevel() {
        StartCoroutine(WaitForSeconds());
    }

    IEnumerator WaitForSeconds() {
        yield return new WaitForSeconds(3.5f);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Gameplay");
        operation.allowSceneActivation = false;
        yield return new WaitForSeconds(12f);
        Wire.CrossFadeAlpha(0, 0.5f, false);
        yield return new WaitForSeconds(3f);
        SoundManager.PlaySound("Ponder");
        yield return new WaitForSeconds(1.1f);
        white.SetActive(true);
        yield return new WaitForSeconds(6f);
        TheNight.CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(4f);
        TheNight.CrossFadeAlpha(0f, 0.5f, false);
        yield return new WaitForSeconds(5f);
        hearing.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(9f);
        hearing.CrossFadeAlpha(0f, 0.5f, false);
        yield return new WaitForSeconds(1f);
        getout.CrossFadeAlpha(1f, 4f, false);
        yield return new WaitForSeconds(5f);
        operation.allowSceneActivation = true;
    }
}
