using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    // Screen
    [SerializeField] GameObject Fall_Screen;
    [SerializeField] GameObject GamePlay_Screen;

    // Number text
    [SerializeField] AdapterNumber adapterNumberInFallGameScreen;
    [SerializeField] AdapterNumber adapterNumberInRecoreGame;

    // Textmesspro 
    [SerializeField] TMP_Text coinsText;
    [SerializeField] TMP_Text killerText;
    [SerializeField] TMP_Text distanceText;

    // Slider
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider MusicSlider;

    // Combobox
    [SerializeField] TickComboBox musicButton;
    [SerializeField] TickComboBox sfxButton;

    // Start is called before the first frame update
    void Start()
    {
        adapterNumberInRecoreGame.listOfImage(Mathf.FloorToInt(PlayerPrefs.GetFloat("OldRecord")));
    }

    // Update is called once per frames
    void Update()
    {
        distanceText.text = ": " + Mathf.FloorToInt(VelocityHandler.Instance.currentDistance) + " m";
        coinsText.text = ": " + SaveSystem.Instance.currentCoins;
        killerText.text = ": " + SaveSystem.Instance.currentSkill;
    }

    public void FallGameScreen()
    {
        Fall_Screen.SetActive(true);
        GamePlay_Screen.SetActive(false);
        adapterNumberInFallGameScreen.listOfImage(Mathf.FloorToInt(VelocityHandler.Instance.currentDistance));

    }

    public void UpdateSlider()
    {
        SFXSlider.value = SaveSystem.Instance.volumeSFX;
        MusicSlider.value = SaveSystem.Instance.volumeMusic;

    }

    public void UpdateTickBox()
    {
        musicButton.isTick = SaveSystem.Instance.isMuteMusicAudio;
        sfxButton.isTick = SaveSystem.Instance.isMuteSFXAudio;

        musicButton.UpdateUI();
        sfxButton.UpdateUI();

    }

    
}
