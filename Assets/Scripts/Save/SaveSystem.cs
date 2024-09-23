using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetData();
    }


    private void GetData()
    {
        if (PlayerPrefs.GetFloat("yourDistance") > PlayerPrefs.GetFloat("OldRecord"))
        {
            PlayerPrefs.SetFloat("OldRecord", PlayerPrefs.GetFloat("yourDistance"));
            PlayerPrefs.GetFloat("OldRecord");
        }
        else
        {
            PlayerPrefs.GetFloat("OldRecord");
        }
    }
}
