using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TMP_Text distanceText;
    [SerializeField] GameObject Fall_Screen;
    [SerializeField] GameObject GamePlay_Screen;
    [SerializeField] AdapterNumber adapterNumberInFallGameScreen;
    [SerializeField] AdapterNumber adapterNumberInRecoreGame;
    // Start is called before the first frame update
    void Start()
    {
        adapterNumberInRecoreGame.listOfImage(Mathf.FloorToInt(PlayerPrefs.GetFloat("OldRecord")));
    }

    // Update is called once per frames
    void Update()
    {
        distanceText.text = "Distance: " + Mathf.FloorToInt(VelocityHandler.Instance.currentDistance);
    }

    public void FallGameScreen()
    {
        Fall_Screen.SetActive(true);
        GamePlay_Screen.SetActive(false);
        adapterNumberInFallGameScreen.listOfImage(Mathf.FloorToInt(VelocityHandler.Instance.currentDistance));

    }

    
}
