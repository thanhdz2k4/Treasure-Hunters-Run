using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehind : MonoBehaviour
{
    [SerializeField]
    float speedSlow;
   
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        float velocity = VelocityHandler.Instance.Velocity.x / speedSlow; 
        pos.x -= velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }
}
