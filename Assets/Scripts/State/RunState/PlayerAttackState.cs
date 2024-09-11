using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : FSMState
{
  
    private void Start()
    {
        stateID = FSMStateID.Attacking;
    }



    public override void CheckTransitionRules(KeyCode transition)
    {
        // Transition to jump
        PlayerController playerController = GetComponent<PlayerController>();
        playerController.SetTransition(transition);
        Debug.Log("PlayerRunState: " + transition);
        
    }

    public override void RunState()
    {
        
    }

   

}
