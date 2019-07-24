using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public GameObject[] setActive;
    public Image[] sprite;
    public Image Line;
    public Button[] buttons;
    public Text[] text;
    public Image Back;
    public GameObject[] interactableSett;
    public Slider slider;
    public GameObject[] inGameText;
    public GameObject[] system;
    public static float currVolume = 0f;
    private static bool change;

    private void Start()
    {
        Back.canvasRenderer.SetAlpha(0.0f);
        for (int x = 0; x < interactableSett.Length; x++)
        {
            interactableSett[x].SetActive(false);
        }

        for (int x = 0; x < text.Length; x++)
        {
            text[x].canvasRenderer.SetAlpha(0.0f);
        }
        Line.canvasRenderer.SetAlpha(0.0f);
        resolutionDropdown.interactable = false;
        slider.interactable = false;
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string> options = new List<string>();

        for (int x = 0; x < resolutions.Length; x++) {
            string option = resolutions[x].width + " x " + resolutions[x].height + " " + resolutions[x].refreshRate + " Hz";
            options.Add(option);

            if (resolutions[x].width == Screen.currentResolution.width &&
                resolutions[x].height == Screen.currentResolution.height &&
                resolutions[x].refreshRate == Screen.currentResolution.refreshRate) {
                currentResolutionIndex = x;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
    }

    private void Update()
    {
        slider.value = currVolume;
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
    }

    public void SetVolume(float volume) {
        currVolume = volume;
        audioMixer.SetFloat("volume", currVolume);
    }

    public void Settings()
    {
        for (int x = 0; x < sprite.Length; x++)
        {
            sprite[x].CrossFadeAlpha(0f, 0.5f, false);
        }

        for (int x = 0; x < buttons.Length; x++)
        {
            buttons[x].interactable = false;
        }

        for (int x = 0; x < text.Length; x++) {
            text[x].CrossFadeAlpha(1f, 0.5f, false);
        }
        resolutionDropdown.interactable = true;
        slider.interactable = true;
        Line.CrossFadeAlpha(1f, 0.5f, false);
        Back.CrossFadeAlpha(1f, 0.5f, false);
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(0.5f);
        for (int x = 0; x < interactableSett.Length; x++) {
            interactableSett[x].SetActive(true);
        }
    }

    public void backButton() {
        for (int x = 0; x < interactableSett.Length; x++)
        {
            interactableSett[x].SetActive(false);
        }

        for (int x = 0; x < sprite.Length; x++)
        {
            sprite[x].CrossFadeAlpha(1f, 0.5f, false);
        }

        for (int x = 0; x < text.Length; x++)
        {
            text[x].CrossFadeAlpha(0f, 0.5f, false);
        }

        for (int x = 0; x < buttons.Length; x++)
        {
            buttons[x].interactable = true;
        }
        Line.CrossFadeAlpha(0f, 0.5f, false);
    }
}
