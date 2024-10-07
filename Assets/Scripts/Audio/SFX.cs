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

  


    public void PlayThrowKnifeClip()
    {
        if(!SaveSystem.Instance.isMuteSFXAudio)
        {
            audioSource.PlayOneShot(ThrowKnifeClip);
        }
       
    }

    public void PlayMouseClickClip()
    {

        if (SaveSystem.Instance.isMuteSFXAudio)
        {
            audioSource.PlayOneShot(MouseClick);
        }
       
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && SaveSystem.Instance.isMuteSFXAudio)
        {
            audioSource.PlayOneShot(MouseClick);
        }
        
    }

    public void UpdateVolumeSFX()
    {
        this.audioSource.volume = SFXSlider.value;
        SaveSystem.Instance.volumeSFX = SFXSlider.value;

    }
}
