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

        // Check if there's saved player data (like the distance they achieved in a previous game)
        if (PlayerPrefs.GetFloat("yourDistance") > 1000)
        {
            
            GetData();  // Load stored preferences
        }
        else
        {
            PlayerPrefs.SetInt("MuteMusic", 1);
            isMute = false;  // Default to audio not being muted
        }

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
    void GetData()
    {
        if (PlayerPrefs.GetInt("MuteMusic") == 1)
        {
            isMute = true;
        }
        else
        {
            isMute = false;
        }
    }

    // Change the audio to the "DuringGameAudio" when gameplay starts
    public void ChangeDuringGameAudio()
    {
        GetData();

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
    }

    // Mute/unmute the music
    public void ToggleMute(bool mute)
    {
        isMute = mute;
        PlayerPrefs.SetInt("MuteMusic", isMute ? 1 : 0);  // Save mute preference

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
