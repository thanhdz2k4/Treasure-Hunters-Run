using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance { get; private set; }
    public int currentCoins { get; private set; }

    public int currentSkill { get; private set; }

    public int coinsPrefs { get; private set; }

    public bool isMuteMusicAudio { get; private set; }
    
    public bool isMuteSFXAudio { get; private set; }

    public float volumeSFX;
    public float volumeMusic;

    [SerializeField]
    bool isMuteMusic;

    [SerializeField]
    bool isMuteSFX;

    private void Update()
    {
        isMuteMusic = isMuteMusicAudio;
        isMuteSFX = isMuteSFXAudio;
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // This makes sure the SaveSystem persists across scenes.
        }
        else
        {
            Destroy(gameObject);  // Ensure only one instance exists.
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetData();
    }


    private void GetData()
    {
        if (PlayerPrefs.GetFloat("yourDistance") > PlayerPrefs.GetFloat("OldRecord"))
        {
            PlayerPrefs.SetFloat("OldRecord", PlayerPrefs.GetFloat("yourDistance"));
            PlayerPrefs.GetFloat("OldRecord");
        }
        else
        {
            PlayerPrefs.GetFloat("OldRecord");
        }

        isMuteMusicAudio = false;
        isMuteSFXAudio = false;


        coinsPrefs = PlayerPrefs.GetInt("yourCoin");
    }

    public void AddCoint(int value)
    {
        currentCoins += value;
        coinsPrefs += value;
        PlayerPrefs.SetInt("yourCoin", coinsPrefs);
    }

    public void AddKill(int value)
    {
        currentSkill += value;
    }

    public void ResetData()
    {
        currentSkill = 0;
        currentCoins = 0;
    }

    public void SetMuteSFX()
    {
        isMuteSFXAudio = !isMuteSFXAudio;
        Debug.Log("isMuteSFXAudio: " + isMuteSFXAudio);
    }

    public void SetMuteBGAudio()
    {
        isMuteMusicAudio = !isMuteMusicAudio;
    }
}
