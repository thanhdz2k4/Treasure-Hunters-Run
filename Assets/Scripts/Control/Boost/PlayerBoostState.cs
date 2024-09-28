using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoostState : FSMState
{
    [SerializeField] Animator animator;
    [Header("Visuals")]
    [Tooltip("Play back particles when boost state is active")]
    [SerializeField] private ParticleSystem BoostVFX;

    private Coroutine speedBoostCoroutine;
    private bool isModifierActive = false;
    private float duration = 0f;




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
        ModifySpeed(3, 5f);
    }

    public void ModifySpeed(float speedMultiplier, float duration)
    {
        Debug.Log("speedMultiplier " + speedMultiplier);
        VelocityHandler.Instance.SpeedMultiplier(speedMultiplier);
    }

    
}
