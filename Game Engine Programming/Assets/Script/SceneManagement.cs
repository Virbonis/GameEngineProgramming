using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public static bool stopMusic;
    private MusicManager music;

    private void Start()
    {
        music = GameObject.Find("Music").GetComponent<MusicManager>();
    }

    public void Gameplay() {
        SceneManager.LoadScene("Gameplay");
    }

    public void quitGame() {
        Application.Quit();
    }

    public void LoadingScreen() {
        SceneManager.LoadScene("Loading Screen");
        MusicManager.played = true;
        stopMusic = true;
    }

    public void CreditMenu() {
        SceneManager.LoadScene("Credit Menu");
        MusicManager.myAudio.volume = 0;
        MusicManager.played = true;
        stopMusic = true;
    }

    public void MenuScreen()
    {
        SceneManager.LoadScene("Menu");
        stopMusic = false;
        MusicManager.played = false;
        FadeTutorial.counter = 0;
        FadeTutorial.KillerTutorialCounter = 0;
        FadeTutorial.useItem = 0;
    }

    public void Credit() {
        SceneManager.LoadScene("Credit");
    }

    public void LoadingTips() {
        SceneManager.LoadScene("Loading Tips");
    }
}
