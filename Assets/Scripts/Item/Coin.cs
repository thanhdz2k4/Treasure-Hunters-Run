using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    [SerializeField]
    private float value;

    public Coin(float value)
    {
        this.value = value;
    }

    public void Collect()
    {
        SaveSystem.Instance.AddCoint((int)value);
    }
}
