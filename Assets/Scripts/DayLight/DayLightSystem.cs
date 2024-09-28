using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayLightSystem : MonoBehaviour
{
    [SerializeField] LightColorController ppv;
    [SerializeField] Light2D GlobalLight;
    [SerializeField]
    float tick;
    [SerializeField]
    float seconds;
    [SerializeField]
    float mins;
    [SerializeField]
    float hours;

    // Update is called once per frame
    void FixedUpdate()
    {
        CalcTime();
    }

    public void CalcTime()
    {
        seconds += Time.fixedDeltaTime + tick;

        if (seconds >= 10)
        {
            seconds = 0;
            mins += 1;
        }

        if (mins >= 30)
        {
            mins = 0;
            hours += 1;
        }

        if (hours >= 20)
        {
            hours = 0;
        }

        ControlPVV();
        ControlGlobaLight();
    }

    private void ControlPVV()
    {
        this.ppv.time = hours / 20;
       
    }

    private void ControlGlobaLight()
    {
        float remain = 0;
        
        if(hours <= 10)
        {
            this.GlobalLight.intensity = 4 - 3 * (hours / 10);
        }
        else
        {
            remain = hours - 10;
            this.GlobalLight.intensity = 1 + 3 * (remain / 10);
            
        }
        
    }

}
