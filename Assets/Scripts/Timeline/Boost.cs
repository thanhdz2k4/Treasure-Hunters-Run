using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoostTimeline : MonoBehaviour
{
    // this is the position player and boat arrive at
    [SerializeField]
    Transform position;

    [SerializeField]
    GameObject Boat;

    [SerializeField]
    GameObject Player;

    [SerializeField]
    float speedMove;

    [SerializeField]
    float distanceToMove;

    bool isActive;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Boost();
        }
        if(isActive)
        {
            Boat.transform.rotation = Quaternion.Slerp(Boat.transform.rotation, Quaternion.Euler(0, 0, 0), 2 * Time.fixedDeltaTime); 
        }
    }

    void Boost()
    {
        // Calculate the distance to the target position
        float distance = Vector3.Distance(position.position, Boat.transform.position);

        // If the boat is not at the target, move it
        if (distance > 0)
        {
            // Move the boat to the exact target position over 'speedMove' seconds
            Boat.transform.DOMove(position.position, speedMove).OnComplete(BoastShake);
        }
    }

    void BoastShake()
    {

        this.isActive = true;

    }
}
