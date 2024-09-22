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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
