using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject RestartWarning;
    public GameObject MenuWarning;
    public GameObject QuitWarning;
    public GameObject[] Options;
    private SceneManagement sceneManager;

    private void Start()
    {
        sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManagement>();
    }

    void Update()
    {
        if (Input.GetKeyDown("escape")) {
            if (isPaused)
            {
                Resume();
            }
            else if (!isPaused && PauseManagerClue.PauseClue == false) {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SoundManager.PlaySound("Resume");
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        SoundManager.PlaySound("Pause");
    }

    public void DeactivateObject() {
        for (int x = 0; x < Options.Length; x++) {
            Options[x].SetActive(false);
        }
    }

    public void Restart() {
        DeactivateObject();
        RestartWarning.SetActive(true);
    }

    public void MenuScreen() {
        Time.timeScale = 1;
        sceneManager.MenuScreen();
        isPaused = false;
    }

    public void Menu() {
        DeactivateObject();
        MenuWarning.SetActive(true);
    }

    public void Quit()
    {
        DeactivateObject();
        QuitWarning.SetActive(true);
    }

    public void Yes() {
        SceneManager.LoadScene("Loading Tips");
        isPaused = false;
        Time.timeScale = 1;
    }

    public void No() {
        for (int x = 0; x < Options.Length; x++)
        {
            Options[x].SetActive(true);
        }
        RestartWarning.SetActive(false);
        QuitWarning.SetActive(false);
        MenuWarning.SetActive(false);
    }
}
