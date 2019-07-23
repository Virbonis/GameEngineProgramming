using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManagerClue : MonoBehaviour
{
    GameObject pause;
    public bool clue;
    private float timer = 0.15f;
    private float timerPause = 0.15f;
    public static bool PauseClue = false;
    FadeInClue fade;

    private void Start()
    {
        pause = GameObject.FindWithTag("Clue GUI");
        fade = gameObject.GetComponent<FadeInClue>();
    }

    private void Update()
    {
        if (pause.activeSelf)
        {
            fade.BackButton.SetActive(true);
            PauseClue = true;
            StartCoroutine(wait());
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Interact") && clue == true && timer < 0)
        {
            Time.timeScale = 1;
            PauseClue = false;
            clue = false;
            gameObject.SetActive(false);
            fade.BackButton.SetActive(false);
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.15f);
        Time.timeScale = 0;
        clue = true;
    }
}
