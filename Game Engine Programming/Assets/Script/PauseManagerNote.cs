using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManagerNote : MonoBehaviour
{
    GameObject pause;
    public GameObject Player;
    public bool Note;
    private float timer = 0.15f;
    private float timerPause = 0.15f;
    public static bool pauseNote = false;
    FadeIn fade;

    private void Start()
    {
        pause = GameObject.FindWithTag("Note GUI");
        fade = gameObject.GetComponent<FadeIn>();
        if (pause.activeSelf)
        {
            pauseNote = true;
            StartCoroutine(wait());
        }
    }

    private void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Interact") && Note == true && timer < 0)
        {
            Player.SetActive(true);
            Time.timeScale = 1;
            Note = false;
            pauseNote = false;
            gameObject.SendMessage("FadeOut");
        }

        if (pauseNote)
        {
            if (timerPause > 0)
            {
                timerPause -= Time.deltaTime;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
        else {
            Time.timeScale = 1;
        }
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(0.15f);
        Time.timeScale = 0;
        Player.SetActive(false);
        Note = true;
    }
}
