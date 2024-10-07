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
    UnityEvent invokeEvent;

    public bool isTick;

    private void Start()
    {
        TickIcon.gameObject.SetActive(true);
    }

    public void ToggleTickIcon()
    {
        isTick = !isTick;
        TickIcon.gameObject.SetActive(isTick);
        invokeEvent.Invoke();
    }

    public void UpdateUI()
    {
        TickIcon.gameObject.SetActive(isTick);
    }
}
