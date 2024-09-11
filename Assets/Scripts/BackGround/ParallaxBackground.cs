using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    int depth;

    [SerializeField]
    float xBound;

    [SerializeField]
    float xInit;

    

  
    private void FixedUpdate()
    {
        float realVelocity = VelocityHandler.Instance.Velocity.x / depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;
        if(pos.x <= xBound)
        {
            pos.x = xInit;
        }
        transform.position = pos;
    }
}
