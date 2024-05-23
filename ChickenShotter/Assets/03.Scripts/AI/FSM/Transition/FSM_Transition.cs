using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FSM_Transition
{
    //Value
    private FSM_Controller _owner;

    public FSM_State NextState;
    private List<FSM_Condition> _transitionConditions;

    public void ResetCondition()
    {
        foreach (FSM_Condition condition in _transitionConditions)
        {
            condition.ResetCondition();
        }
    }
    public bool Check_TransitionConditions()
    {

        foreach (FSM_Condition condition in _transitionConditions)
        {

            if(condition.Check_FSMCondition() == false)
                return false;

        }

        return true;
    }
    public void SetOwner(FSM_Controller owner)
    {
        _owner = owner;
        foreach(FSM_Condition condition in _transitionConditions)
        {
            condition.SetOwner(owner);
        }    
    }
}
