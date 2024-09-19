using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : FSMState
{
    [SerializeField]
    private float jumpVelocity = 20f;

    [SerializeField]
    private bool isGround = false;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Collider2D myFoot;

    [SerializeField]
    private bool isJumping = false;

    [SerializeField]
    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myFoot = GetComponent<Collider2D>();
        stateID = FSMStateID.Jumping;
        animator = GetComponent<Animator>();
    }

    

    public override void CheckTransitionRules(KeyCode transition)
    {
        // Check the player input 
        // When the input is none, transition to run state
        // Transition logic here
        PlayerController playerController = GetComponent<PlayerController>();
        playerController.SetTransition(transition);
       // Debug.Log("playerJumstate: " + transition);
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

        // Check if the player is grounded
        isGround = IsGround();

        // If player is grounded and jump key is pressed, allow jump
        if (isGround && Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            Jump();
        }

        // Optional: if you want to stop upward velocity when key is released
        if (isJumping && Input.GetKeyUp(KeyCode.Space))
        {
            StopJumpEarly();
        }

        animator.SetFloat("YVelocity", rb.velocity.x);
       
    }

    private void Jump()
    {
        // Apply jump force in the Y direction
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
    }

    private void StopJumpEarly()
    {
        // This will allow the player to cut the jump short if they release the key early
        if (rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);  // Reduce jump height
        }
        isJumping = false;  // Reset jumping state
    }

    public bool IsGround()
    {
        // Check if the player's foot collider is touching the ground layer
        return this.myFoot.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}
