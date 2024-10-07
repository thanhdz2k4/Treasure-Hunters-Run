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
        }
  
    }

    public void ChangeDuringGameAudio()
    {
       
        if (DuringGameAudio != null  && SaveSystem.Instance.isMuteMusicAudio)
        {
            audioSource.clip = DuringGameAudio;
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }


}
