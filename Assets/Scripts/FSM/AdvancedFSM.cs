using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedFSM : FSM
{
    private List<FSMState> fsmsStates = new List<FSMState>();

    // The fsmsState are not chaning directy but updated by using transition
    [SerializeField]
    private FSMStateID currentStateID;
    public FSMStateID CurrentStateID {get { return currentStateID; } }

    [SerializeField]
    private FSMState currentState;
    public FSMState CurrentState { get { return currentState; } }

    

    // Add new state into the list
    public void AddFSMState(FSMState fsmState)
    {
        // Check for null reference before deleting
        if(fsmState == null)
        {
            Debug.LogError("FSM ERROR: Null reference is not allowed");
        }

        // First state inserted is also the initial state
        // The state the machine is in when the simulation begins
        if(fsmsStates.Count == 0)
        {
            fsmsStates.Add(fsmState);
            currentState = fsmState;
            currentStateID = fsmState.ID;
            Debug.Log("currentState: " + currentState + "   CurrentStateID: " + currentStateID);
            return;
        }

        // Add the state to the list if it's not inside it
        foreach(FSMState state in fsmsStates)
        {
            if(state.ID == fsmState.ID)
            {
                Debug.LogError("FSM ERROR: Trying to add a state that was already inside the list");
                return;
            }
        }

        // if not state in the current then add the state to the list
        fsmsStates.Add(fsmState);
    }

    // This is method delete a state from the FSM List if it exists
    // or prints an ERROR message if the state was not on the List.
    public void DeleteState(FSMStateID fsmState)
    {
        // Check for NullState before deleting
        if(fsmState == FSMStateID.None)
        {
            Debug.LogError("FSM ERROR: bull id is not allowed");
            return;
        }

        // Search the list and delete the satate if it's inside it
        foreach(FSMState state in fsmsStates)
        {
            if(state.ID == fsmState) 
            {
                fsmsStates.Remove(state);
                return;
            }
        }
        Debug.LogError("FSM ERROR: The state passed was not on the list. Impossible to delete it");
    }


    // This method tries to change the state the FSM is in based on
    // the current state and the transition passed. If current state
    // doesn't have a target state for the transition passed,
    // an ERROR message is printed
    public void PerformTransition(KeyCode trans)
    {
        if (trans == KeyCode.None)
        {
            Debug.LogError("FSM ERROR: Null transition is not allowed");
            return;
        }

        // Check if the currentState has the transition passed as argument
        FSMStateID id = currentState.GetOutputState(trans);
        if (id == FSMStateID.None)
        {
            Debug.LogError($"FSM ERROR: Current State {currentStateID} does not have a target state for this transition {trans}");
            return;
        }

        // Log state change
        Debug.Log($"Transitioning from {currentStateID} to {id} on key press: {trans}");

        // Update the currentStateID and currentState		
        currentStateID = id;
        foreach (FSMState state in fsmsStates)
        {
            if (state.ID == currentStateID)
            {
                currentState = state;
                break;
            }
        }
    }

}
