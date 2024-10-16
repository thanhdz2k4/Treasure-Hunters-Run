using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TickComboBox : MonoBehaviour
{
    [SerializeField]
    Image TickIcon;

    [SerializeField]
    string mute;

    [SerializeField]
    bool isTick;

    [SerializeField]
    UnityEvent unityEvent;

    private void UpdateComboBox()
    {
        if (PlayerPrefs.GetInt(mute) == 1)
        {
            TickIcon.gameObject.SetActive(false);
        }
        else
        {
            TickIcon.gameObject.SetActive(true);
        }
    }

    public void ToggleTickIcon()
    {
        isTick = !isTick;
        if (isTick)
        {
            PlayerPrefs.SetInt(mute, 0);
        }
        else
        {
            PlayerPrefs.SetInt(mute, 1);
        }
        UpdateComboBox();
        unityEvent.Invoke();
        Debug.Log(PlayerPrefs.GetInt(mute) + "    " + mute);
    }

    public void UpdateUI()
    {
        if (PlayerPrefs.GetFloat("yourDistance") > 1000)
        {
            isTick = false;
            TickIcon.gameObject.SetActive(false);
        }
        else
        {
            UpdateComboBox();
        }
    }
}