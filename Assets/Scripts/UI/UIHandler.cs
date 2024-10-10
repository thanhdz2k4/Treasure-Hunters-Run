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
    [SerializeField] SliderUI SFXSlider;
    [SerializeField] SliderUI MusicSlider;

    // Combobox
    [SerializeField] TickComboBox musicButton;
    [SerializeField] TickComboBox sfxButton;

    private bool isTickButtonReset = false;

    

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
        if(!isTickButtonReset)
        {
            Fall_Screen.SetActive(true);
            GamePlay_Screen.SetActive(false);
            adapterNumberInFallGameScreen.listOfImage(Mathf.FloorToInt(VelocityHandler.Instance.currentDistance));
            Debug.Log(" Fall_Screen.SetActive(true)");
            isTickButtonReset = true;

        }


    }

    public void UnacticeFallGameScreen()
    {
        Fall_Screen.SetActive(false);
        Debug.Log(" Fall_Screen.SetActive(false)");

        StartCoroutine(Delay(1f));
    }

    IEnumerator Delay(float timer)
    {
        yield return new WaitForSeconds(timer);
        isTickButtonReset = false;
    }

    public void UpdateSlider()
    {
       

    }

    public void UpdateTickBox()
    {
       

        musicButton.UpdateUI();
        sfxButton.UpdateUI();

    }

    
}
