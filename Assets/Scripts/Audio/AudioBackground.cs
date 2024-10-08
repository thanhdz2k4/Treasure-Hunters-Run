using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioBackground : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip StartGameAudio;

    [SerializeField]
    AudioClip DuringGameAudio;

    [SerializeField]
    Slider musicSlider;  // Reference to the volume control slider

    [SerializeField]
    private bool isMute;

    void Start()
    {
        // Initialize audio source
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Set the audio to StartGameAudio
        if (StartGameAudio != null)
        {
            audioSource.clip = StartGameAudio;
        }

        // Load stored player preferences
        LoadData();

        // Play or pause the audio based on the mute status
        if (!isMute)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }

        // Initialize the music slider if it's assigned
        if (musicSlider != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);  // Load saved volume
            audioSource.volume = musicSlider.value;
            musicSlider.onValueChanged.AddListener(ChangeVolume);
        }
    }

    // Load mute setting from PlayerPrefs
    void LoadData()
    {
        isMute = PlayerPrefs.GetInt("MuteMusic", 0) == 1;  // Default to not muted (0)
    }

    // Change the audio to the "DuringGameAudio" when gameplay starts
    public void ChangeDuringGameAudio()
    {
        LoadData();

        // If the audio clip exists and audio is not muted, play it
        if (DuringGameAudio != null && !isMute)
        {
            audioSource.clip = DuringGameAudio;
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();  // Pause if muted
        }
    }

    // Change volume based on the slider
    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);  // Save volume preference
        PlayerPrefs.Save();  // Save the preferences to disk
    }

    // Mute/unmute the music
    public void ToggleMute(bool mute)
    {
        isMute = mute;
        PlayerPrefs.SetInt("MuteMusic", isMute ? 1 : 0);  // Save mute preference
        PlayerPrefs.Save();  // Save the preferences to disk

        if (isMute)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}
