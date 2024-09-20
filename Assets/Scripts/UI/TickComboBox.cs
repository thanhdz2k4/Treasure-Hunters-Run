using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TickComboBox : MonoBehaviour
{
    [SerializeField]
    Image TickIcon; 

    public bool isTick { get; private set; }

    private void Start()
    {
        TickIcon.gameObject.SetActive(true);
    }

    public void ToggleTickIcon()
    {
        isTick = !isTick;
        TickIcon.gameObject.SetActive(!isTick);
    }
}
