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
    Slider musicSlider;

    [SerializeField]
    TickComboBox comboBoxMusic;
    

    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (StartGameAudio != null)
        {
            audioSource.clip = StartGameAudio;
            audioSource.Play();
            Debug.Log("Playing StartGameAudio");
        }
        else
        {
            Debug.LogError("StartGameAudio not assigned!");
        }
    }

    public void ChangeDuringGameAudio()
    {
       
        if (DuringGameAudio != null)
        {
            audioSource.clip = DuringGameAudio;
            audioSource.Play();
            Debug.Log("Changed to DuringGameAudio and playing.");
        }
        else
        {
            Debug.LogError("DuringGameAudio not assigned!");
        }


        UpdateVolume();


    }


    public void UpdateVolume()
    {
        this.audioSource.volume = musicSlider.value;
        if (comboBoxMusic.isTick)
        {
            audioSource.Pause();
        }
        else
        {
            //audioSource.Play();

        }
    }

 
}
