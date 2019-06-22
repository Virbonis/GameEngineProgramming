using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager: MonoBehaviour
{
    GameObject pause;
    public GameObject Player;
    private bool keyGUI;

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
        }
        if (Input.GetButtonDown("Interact") && keyGUI == true)
        {
            pause.SetActive(false);
            Player.SetActive(true);
            Time.timeScale = 1;
            keyGUI = false;
        }
    }
}
