using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class FSM_State : MonoBehaviour
{
    // Owner
    private FSM_Controller _owner;
    private List<FSM_Transition> _transitions;

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
        foreach(FSM_Transition transition in _transitions)
        {
            transition.SetOwner(owner);
        }
    }

    // Set State Name
    private void OnValidate()
    {
        name = this.GetType().Name;
    }

    protected abstract void EnterState();
    protected abstract void UpdateState();
    protected abstract void ExitState();

    
}
