using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour, IProduct
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioClip collectAudio;

    [SerializeField]
    string Name;
    public string ProductName { get => Name; set => Name = value; }

    [SerializeField]
    float value;

    [SerializeField]
    float xDespawn;

    [SerializeField]
    float timerDelaySpawn;

    private void Update()
    {
        if(transform.position.x < xDespawn)
        {
            Destroy();
        }
    }

    public void Initialize()
    {
        audioSource.Stop();
        gameObject.name = Name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //SaveSystem.Instance.AddCoint((int)value);
            audioSource.PlayOneShot(collectAudio);
            StartCoroutine(DestroyAfterAudio());
        }
    }

    private IEnumerator DestroyAfterAudio()
    {
        Debug.Log("Play audio");
        yield return new WaitForSeconds(collectAudio.length - timerDelaySpawn);
        
        Debug.Log(collectAudio.length);
        Destroy();
    }


    public void Destroy()
    {
        gameObject.transform.SetParent(null);
        gameObject.SetActive(false);
    }




}
