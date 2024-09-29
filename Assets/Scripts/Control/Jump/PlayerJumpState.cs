using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : FSMState
{

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    Collider2D myFoot;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Jump Jump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myFoot = GetComponent<Collider2D>();
        stateID = FSMStateID.Jumping;
        animator = GetComponent<Animator>();
        Jump = GetComponent<Jump>();
    }

    public override void CheckTransitionRules(KeyCode transition)
    {
        PlayerController playerController = GetComponent<PlayerController>();
        playerController.SetTransition(transition);
    }

    private void Update()
    {
        //DoJumping();
        animator.SetBool("isJumping", !IsGround());
    }

    public override void RunState()
    {
        DoJumping();
    }


    private void DoJumping()
    {
        
            Jump.DoJumping(IsGround());
        
        animator.SetFloat("YVelocity", rb.velocity.x);
       
    }
    public bool IsGround()
    {
        // Check if the player's foot collider is touching the ground layer
        return this.myFoot.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}
