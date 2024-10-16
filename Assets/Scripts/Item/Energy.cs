using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour, ICollectible
{
    [SerializeField]
    Slider energybar;

    [SerializeField]
    private float value;

    private void Start()
    {
        energybar = GameObject.Find("Energy_Slider").GetComponent<Slider>();
    }

    public Energy(float value)
    {
        this.value = value;
    }

    public void Collect()
    {
        energybar.value += value;
    }
}
