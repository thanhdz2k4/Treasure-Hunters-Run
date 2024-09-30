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
    GameObject Player_Boat;

    [SerializeField]
    float speedMove;

    [SerializeField]
    bool isActive;



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
            Boat.SetActive(false);
            Player.SetActive(false);
            Player_Boat.SetActive(true);
            isActive = false;
        }
    }

    void Boost()
    {
        Boat.SetActive(true);
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
        Player_Boat.transform.position = Boat.transform.position;
        this.isActive = true;
    }
}
