using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IProduct
{
    [SerializeField]
    AudioSource audio;

    [SerializeField]
    AudioClip collectCoinAudio;

    [SerializeField]
    string NameCoin;
    public string ProductName { get => NameCoin; set => NameCoin = value; }

    [SerializeField]
    int value;

    [SerializeField]
    float xDespawn;

    private void Update()
    {
        if(transform.position.x < xDespawn)
        {
            Destroy();
        }
    }

    public void Initialize()
    {
        audio.Stop();
        gameObject.name = NameCoin;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SaveSystem.Instance.AddCoint(value);
            audio.PlayOneShot(collectCoinAudio);
            StartCoroutine(DestroyAfterAudio());
        }
    }

    private IEnumerator DestroyAfterAudio()
    {
        Debug.Log("Play audio");
        yield return new WaitForSeconds(collectCoinAudio.length);
        Destroy();
    }


    public void Destroy()
    {
        gameObject.transform.SetParent(null);
        gameObject.SetActive(false);
    }




}
