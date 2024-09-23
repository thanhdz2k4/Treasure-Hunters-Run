using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip ThrowKnifeClip;
    

    public void PlayThrowKnifeClip()
    {
        audioSource.PlayOneShot(ThrowKnifeClip);
    }
}
