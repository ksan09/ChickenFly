using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FSM_State<T> where T : Enum
{
    // Owner
    private FSM_Controller<T> _owner;

    private List<FSM_Transition<T>> _transitions;
    public List<FSM_Transition<T>> Transitions => _transitions;

    public FSM_State(FSM_Controller<T> owner)
    {
        _owner = owner;
        _transitions = new List<FSM_Transition<T>>();


    }

    public bool CheckTransition()
    {

        foreach (FSM_Transition<T> transition in _transitions)
        {

            if(transition.Check_TransitionConditions())
            {

                _owner.ChangeState(transition.NextState);
                return true;

            }

        }

        return false;

    }

    public void EnterFSMState()
    {
        //
        foreach(FSM_Transition<T> transition in _transitions)
        {
            transition.ResetCondition();
        }

        EnterState();
    }
    public void RunFSMState()
    {
        if(CheckTransition())
        {
            return;
        }

        UpdateState();
    }
    public void ExitFSMState()
    {
        //
        ExitState();
    }

    public void AddTransition(FSM_Transition<T> transition)
    {

        _transitions.Add(transition);

    }

    protected virtual void EnterState()
    {

    }

    protected virtual void UpdateState()
    {

    }

    protected virtual void ExitState()
    {

    }

    
}
