using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boost : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    [SerializeField]
    Jump Jump;

    [SerializeField]
    Collider2D myFoot;

    [SerializeField]
    float timer;

    [SerializeField]
    float timerDelay = 3;

    private void Start()
    {
        Jump = GetComponent<Jump>();
    }
    // Update is called once per frame
    void Update()
    {
        if(IsGround())
        {
            Jump.DoJumping(IsGround());
            VelocityHandler.Instance.SpeedMultiplier(4);
            
        }

        timer += Time.deltaTime;
        if(timer >= timerDelay)
        {
            VelocityHandler.Instance.SpeedMultiplier(10);
            gameObject.SetActive(false);
            Player.SetActive(true);
            timer = 0;
        }
    }

    public bool IsGround()
    {
        Debug.Log( this.myFoot.IsTouchingLayers(LayerMask.GetMask("Ground")) || this.myFoot.IsTouchingLayers(LayerMask.GetMask("Bound")));
        // Check if the player's foot collider is touching the ground layer
        return this.myFoot.IsTouchingLayers(LayerMask.GetMask("Ground")) || this.myFoot.IsTouchingLayers(LayerMask.GetMask("Bound"));
    }
}
