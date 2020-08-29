using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private AudioMixerGroup MasterAudioMixer;

    // Pause/Unpause game
    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseUI.SetActive(true);
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1.0f;
        PauseUI.SetActive(false);
    }

    // Sound settings
    public void ToogleMusic(bool Enabled)
    {
        // Sound on
        if (Enabled)
        {
            MasterAudioMixer.audioMixer.SetFloat("MusicVolume", 0f);
        }
        // Sound off
        else
        {
            MasterAudioMixer.audioMixer.SetFloat("MusicVolume", -80f);
        }
    }

    public void ChangeVolume(float volume)
    {
        // '-80' = 0 and '0' = 1 for lerp function
        MasterAudioMixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
    }
}
