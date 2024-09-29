using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    private float jumpVelocity = 25f;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void DoJumping(bool isActiveJump)
    {
        // If player is grounded and jump key is pressed, allow jump
        if (isActiveJump && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            JumpHigher();
        }

        // Optional: if you want to stop upward velocity when key is released
        if (isJumping && Input.GetKeyUp(KeyCode.Space))
        {
            StopJumpEarly();
        }

    }

    private void JumpHigher()
    {
        // Apply jump force in the Y direction
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
    }

    private void StopJumpEarly()
    {
        // This will allow the player to cut the jump short if they release the key early
        if (rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.7f);  // Reduce jump height
        }
        isJumping = false;  // Reset jumping state
    }
}
