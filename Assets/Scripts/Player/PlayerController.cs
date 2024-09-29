using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AdvancedFSM
{
    [SerializeField]
    PlayerJumpState JumpState;

    [SerializeField]
    PlayerAttackState AttackState;


    protected override void Initialize()
    {
        JumpState = GetComponent<PlayerJumpState>();
        AttackState = GetComponent<PlayerAttackState>();
        ContructFSM();

       
    }
    protected override void FSMFixUpdate()
    {

     
    }
    private KeyCode GetPressedKey()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                //Debug.Log(keyCode);
                return keyCode;  // Return the pressed key
                
            }
        }

        return KeyCode.None;  // If no key was pressed, return None
    }
    protected override void FSMUpdate()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1f))
        {

            Debug.Log("OnTheGround");
        }
        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red);
        KeyCode pressedKey = GetPressedKey();  // Detect pressed key
        if (pressedKey != KeyCode.None)
        {
            CurrentState.CheckTransitionRules(pressedKey);  // Check transition rules with the detected key
        }

        // Run the current state's logic
        CurrentState.RunState();
    }

    public void SetTransition(KeyCode transition)
    {
        PerformTransition(transition);
    }

    private void ContructFSM()
    {

        JumpState.AddTransition(KeyCode.A, FSMStateID.Attacking);
        JumpState.AddTransition(KeyCode.B, FSMStateID.Boosting);
        AddFSMState(JumpState);

        AttackState.AddTransition(KeyCode.Space, FSMStateID.Jumping);
        AttackState.AddTransition(KeyCode.B, FSMStateID.Boosting);
        AddFSMState(AttackState);

    }


}
