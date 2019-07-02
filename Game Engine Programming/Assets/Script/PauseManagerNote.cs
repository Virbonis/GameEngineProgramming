using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManagerNote : MonoBehaviour
{
    GameObject pause;
    public GameObject Player;
    public bool Note;
    FadeIn fade;

    private void Start()
    {
        pause = GameObject.FindWithTag("Note GUI");
        fade = gameObject.GetComponent<FadeIn>();
        if (pause.activeSelf)
        {
            StartCoroutine(wait());
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && Note == true)
        {
            Player.SetActive(true);
            Time.timeScale = 1;
            Note = false;
            gameObject.SendMessage("FadeOut");
        }
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(0.15f);
        Time.timeScale = 0;
        Player.SetActive(false);
        Note = true;
    }
}
