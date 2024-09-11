using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FSMStateID
{
    None = 0,
    Jumping,
    Attacking,
}

public abstract class FSMState : MonoBehaviour
{
    protected Dictionary<KeyCode, FSMStateID> map = new Dictionary<KeyCode, FSMStateID>();
    protected FSMStateID stateID;
    public FSMStateID ID { get { return stateID; } }

    public void AddTransition(KeyCode transition, FSMStateID id)
    {
        // Since this is a determinstc FSM
        // Check if the current transition was already inside the map
        if(map.ContainsKey(transition))
        {
            Debug.LogError("FSMState ERROR: Transition is already inside the map");
            return;
        }

        map.Add(transition, id);
        Debug.Log("Added : " + transition + " with ID : " + id);
    }

    // This method deletes a pair transition-state from this state map
    // If the transition was not inside the state map, an ERROR message is printed.
    public void DeleteTransition(KeyCode trans)
    {
        // Check if the pair is inside the map before deleting
        if(map.ContainsKey(trans))
        {
            map.Remove(trans);
            return;
        }
        
    } 

    // this method returns the new state the FSM shoud be if this state receives a transition
    public FSMStateID GetOutputState(KeyCode trans)
    {
        if(trans != KeyCode.None)
        {
            if (map.ContainsKey(trans))
            {
                return map[trans];
            }

        }

        Debug.LogError("FSMState ERROR: " + trans + " Transition passed to the state was not on the list");
        return FSMStateID.None;
    }


    // Decides if the state should transition to another on its list
    public abstract void CheckTransitionRules(KeyCode transition);

    // This method controls the behavior of the player, npc, .. in the game world
    public abstract void RunState();
    



    
}
