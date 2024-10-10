using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
    [SerializeField]
    string name;

    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        SetValue();
    }


    public void SetValue()
    {
        slider.value = PlayerPrefs.GetFloat(name);
    }
}
