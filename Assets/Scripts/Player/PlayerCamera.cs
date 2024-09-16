using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float xBound;
    [SerializeField] Transform playerPosition;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        //xBound = playerPosition.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerPosition.localPosition.x < xBound)
        {
            playerPosition.localPosition += Vector3.right * speed * Time.deltaTime;
           
        }
    }
}
