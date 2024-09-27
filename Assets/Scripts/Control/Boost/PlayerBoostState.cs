using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoostState : FSMState
{
    [SerializeField] Animator animator;
    [SerializeField] float timerDelayBoost;
    float timer;
    bool isGround;

    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    public override void CheckTransitionRules(KeyCode transition)
    {
        PlayerController playerController = GetComponent<PlayerController>();
        playerController.SetTransition(transition);
    }

    public override void RunState()
    {
        DoBoosting();
    }

    private void DoBoosting()
    {
        timer += Time.deltaTime;
        if(timer >= timerDelayBoost)
        {
            animator.SetBool("isBoosting", true);
            timer = 0;
        }
        else
        {
            animator.SetBool("isBoosting", false);
        }
    }

    private void IsOnGround()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1f))
        {

            Debug.Log("OnTheGround");
        }
    }

    
}
