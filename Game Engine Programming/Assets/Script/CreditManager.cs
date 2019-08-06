using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{
    public GameObject credit;
    public GameObject Blackscreen;
    public GameObject Buttons;
    public AudioSource audioVolume;
    private SceneManagement scene;
    public Text text;
    public Image esc;
    private float timer;
    private bool ableToPress;
    private bool pressed;

    void Start()
    {
        scene = GameObject.FindWithTag("Scene Manager").GetComponent<SceneManagement>();
        text.canvasRenderer.SetAlpha(0.0f);
        esc.canvasRenderer.SetAlpha(0.0f);
        timer = 6f;
        ableToPress = false;
        pressed = false;
        StartCoroutine(Wait());
    }

    void Update()
    {
        if (timer > 0)
        {
            ableToPress = false;
            timer -= Time.deltaTime;
        }
        else {
            ableToPress = true;
        }

        if (Input.GetKeyDown("escape") && ableToPress) {
            Buttons.SetActive(false);
            StartCoroutine(BlackScreen());
            pressed = true;
        }

        if (pressed) {
            Blackscreen.SetActive(true);
            audioVolume.volume -= Time.deltaTime * 0.2f;
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(4f);
        credit.SetActive(true);
        yield return new WaitForSeconds(6f);
        text.CrossFadeAlpha(1f, 1f, false);
        esc.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(85f);
        esc.CrossFadeAlpha(0f, 1f, false);
        text.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(5f);
        scene.MenuScreen();
    }

    IEnumerator BlackScreen() {
        yield return new WaitForSeconds(5f);
        scene.MenuScreen();
    }
}
