using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackState : FSMState
{
    [SerializeField]
    Slider AttackBarEnegry;

    [SerializeField]
    float energy;

    [SerializeField]
    float energyToAttack;

    [SerializeField]
    float energyRecover;

    [SerializeField]
    Animator animator;

    [SerializeField]
    SpawnSword spawnSword;

    [SerializeField] SFX SFX;

    private float timer;

    private float timerDelayToRecoverEnergy = 2f;

    private void Start()
    {
        stateID = FSMStateID.Attacking;
        UpdateUI();
    }


    public override void CheckTransitionRules(KeyCode transition)
    {
        PlayerController playerController = GetComponent<PlayerController>();
        playerController.SetTransition(transition);
        //Debug.Log("playerJumstate: " + transition);
    }

    public override void RunState()
    {
        DoAttack();
    }

    public void Update()
    {
        RecoverEnegry();
    }

    private void SetAnimationAttack(bool isAttack)
    {
        this.animator.SetBool("isAttack", isAttack);
    }

    private void DoAttack()
    {
        if(Input.GetKeyDown(KeyCode.A) && energy >= energyToAttack)
        {
            SFX.PlayThrowKnifeClip();
            SetAnimationAttack(true);
            spawnSword.Spawn(); 
            CalculateRemainEnergy();
            RecoverEnegry();
        } else
        {
            SetAnimationAttack(false);
        }
        
       
    }
    
    // when player press attack, minus energy
    private void CalculateRemainEnergy()
    {
        if(energy >= energyToAttack)
        {
            energy -= energyToAttack;
            UpdateUI();
        }
    }

    private void RecoverEnegry()
    {
        if(energy >= 0 && energy <= 100)
        {
            timer += Time.deltaTime;
            if (timer >= timerDelayToRecoverEnergy)
            {
                timer = 0;
                energy += energyRecover;
                UpdateUI();
            }
        }
        
    }

    private void UpdateUI()
    {
        this.AttackBarEnegry.value = energy;
    }
}
