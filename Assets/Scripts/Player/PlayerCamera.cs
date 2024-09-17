using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float xBound;
    [SerializeField] Transform playerPosition;
    [SerializeField] float speed;
    [SerializeField] bool isActive;
    
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        StartCoroutine(DelayBeginTimeline(4));
    }

    IEnumerator DelayBeginTimeline(float timer)
    {
        yield return new WaitForSeconds(timer);
        isActive = true;
    }

   

    // Update is called once per frame
    void Update()
    {

        if (playerPosition.localPosition.x < xBound && isActive)
        {
            playerPosition.localPosition += Vector3.right * speed * Time.deltaTime;

        }
    }
}
