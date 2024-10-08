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
        if(PlayerPrefs.GetInt("MuteSFX") == 1)
        {
            isMute = true;
        } else
        {
            isMute = false;
        }
    }



    public void PlayThrowKnifeClip()
    {
        if(!isMute)
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
        if(Input.GetMouseButtonDown(0) && !isMute)
        {
            audioSource.PlayOneShot(MouseClick);
        }
        
    }

    public void UpdateVolumeSFX()
    {
        this.audioSource.volume = SFXSlider.value;
       

    }
}
