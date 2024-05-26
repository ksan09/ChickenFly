using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public abstract class FSM_State : FSM_NameIsType
{
    // Owner
    private FSM_Controller _owner;

    private List<FSM_Transition> _transitions;
    public List<FSM_Transition> Transitions => _transitions;

    public bool CheckTransition()
    {

        foreach (FSM_Transition transition in _transitions)
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
        foreach(FSM_Transition transition in _transitions)
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

    public void SetOwner(FSM_Controller owner)
    {
        _owner = owner;

        _transitions = transform.GetComponentsInChildren<FSM_Transition>().ToList<FSM_Transition>();
        foreach (FSM_Transition transition in _transitions)
        {
            transition.SetOwner(owner);
        }
    }

    protected abstract void EnterState();
    protected abstract void UpdateState();
    protected abstract void ExitState();

    
}
