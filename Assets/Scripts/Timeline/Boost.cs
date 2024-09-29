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

    [SerializeField]
    bool isActive;

    [SerializeField]
    float timer;

    [SerializeField]
    float timerDelay;

    [SerializeField]
    Jump Jump;

    [SerializeField]
    Collider2D myFoot;

    private void Start()
    {
        Jump = GetComponent<Jump>();
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
           VelocityHandler.Instance.SpeedMultiplier(3);

            //Player.transform.SetParent(Boat.transform);
        }
        else
        {
            VelocityHandler.Instance.SpeedMultiplier(10);

        }

        Jump.DoJumping(IsGround());


       /* timer += Time.deltaTime;
        if (isActive)
        {
            if (timer >= timerDelay)
            {
                isActive = false;
                timer = 0;
            }
        }*/

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
        this.isActive = true;
        

    }

    public bool IsGround()
    {
        Debug.Log( this.myFoot.IsTouchingLayers(LayerMask.GetMask("Ground")) || this.myFoot.IsTouchingLayers(LayerMask.GetMask("Bound")));
        // Check if the player's foot collider is touching the ground layer
        return this.myFoot.IsTouchingLayers(LayerMask.GetMask("Ground")) || this.myFoot.IsTouchingLayers(LayerMask.GetMask("Bound"));
    }
}
