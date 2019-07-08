using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static bool stopMusic;

    public void Gameplay() {
        SceneManager.LoadScene("Gameplay");
    }

    public void quitGame() {
        Application.Quit();
    }

    public void LoadingScreen() {
        SceneManager.LoadScene("Loading Screen");
        stopMusic = true;
    }

    public void MenuScreen()
    {
        SceneManager.LoadScene("Menu");
        stopMusic = false;
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
