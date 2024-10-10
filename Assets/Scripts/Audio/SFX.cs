using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX : MonoBehaviour
{
    // component
    [SerializeField] AudioSource audioSource;

    // soucre
    [SerializeField] AudioClip ThrowKnifeClip;
    [SerializeField] AudioClip MouseClick;

    // UI
    [SerializeField] Slider SFXSlider;

    [SerializeField]
    bool isMute;


    private void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume");

        LoadData();
    }


    // Load mute setting from PlayerPrefs
    public void LoadData()
    {
        isMute = PlayerPrefs.GetInt("MuteSFX", 0) == 1;  // Default to not muted (0)
    }





    public void PlayThrowKnifeClip()
    {
       
        if (!isMute)
        {
            audioSource.PlayOneShot(ThrowKnifeClip);
        }
       
    }

    public void PlayMouseClickClip()
    {
        
        if (!isMute)
        {
            audioSource.PlayOneShot(MouseClick);
        }
       
    }

    private void Update()
    {
        //LoadData();
        if (Input.GetMouseButtonDown(0))
        {
          
            if(!isMute)
            {
                audioSource.PlayOneShot(MouseClick);
            }
            
        }
        
    }

    // Change volume based on the slider
    public void ChangeVolume(Slider volume)
    {
        audioSource.volume = volume.value;
        PlayerPrefs.SetFloat("SFXVolume", volume.value);  // Save volume preference
        PlayerPrefs.Save();  // Save the preferences to disk
    }

    public void UpdateVolumeSFX()
    {

        this.audioSource.volume = SFXSlider.value;
    }

    
}
