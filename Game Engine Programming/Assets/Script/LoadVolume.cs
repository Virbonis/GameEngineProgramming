using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LoadVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;

    private void Awake()
    {
        slider.value = SettingsMenu.currVolume;
    }

    public void SetVolume(float volume)
    {
        SettingsMenu.currVolume = volume;
        audioMixer.SetFloat("volume", SettingsMenu.currVolume);
    }
}
