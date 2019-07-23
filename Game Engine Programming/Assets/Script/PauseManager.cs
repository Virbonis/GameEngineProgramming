using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager: MonoBehaviour
{
    GameObject pause;
    public GameObject backButton;
    public GameObject Player;
    public GameObject tutorial;
    private bool keyGUI;
    public static bool PauseKey = false;

    private void Start()
    {
        pause = GameObject.FindWithTag("GUI");
    }

    private void Update()
    {
        if (pause.activeSelf)
        {
            Time.timeScale = 0;
            keyGUI = true;
            backButton.SetActive(true);
            PauseKey = true;
        }
        if (Input.GetButtonDown("Interact") && keyGUI == true)
        {
            pause.SetActive(false);
            Player.SetActive(true);
            PauseKey = false;
            Time.timeScale = 1;
            keyGUI = false;
            backButton.SetActive(false);
        }

        if (PauseKey == true) {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }
}
