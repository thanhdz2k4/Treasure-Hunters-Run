using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip ThrowKnifeClip;
    [SerializeField] AudioClip MouseClick;
    [SerializeField] Slider SFXSlider;
    [SerializeField] TickComboBox comboBoxSFX;




    public void PlayThrowKnifeClip()
    {
        if(!comboBoxSFX.isTick)
        {
            audioSource.PlayOneShot(ThrowKnifeClip);
        }
       
    }

    public void PlayMouseClickClip()
    {

        if (!comboBoxSFX.isTick)
        {
            audioSource.PlayOneShot(MouseClick);
        }
       
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !comboBoxSFX.isTick)
        {
            audioSource.PlayOneShot(MouseClick);
        }
        
    }

    public void UpdateVolumeSFX()
    {
        this.audioSource.volume = SFXSlider.value;
    }
}
