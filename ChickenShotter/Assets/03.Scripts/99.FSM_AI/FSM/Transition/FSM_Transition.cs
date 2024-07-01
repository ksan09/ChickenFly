using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FSM_Transition<T> where T : Enum
{
    //Value
    private FSM_Controller<T> _owner;

    private T _nextState;
    public T NextState => _nextState;
    private List<FSM_Condition> _transitionConditions;

    public FSM_Transition(FSM_Controller<T> owner, T nextState)
    {
        _owner = owner;
        _nextState = nextState;
        _transitionConditions = new List<FSM_Condition>();

    }

    public void AddCondition(FSM_Condition condition)
    {
        _transitionConditions.Add(condition);
    }

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

}
