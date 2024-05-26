using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FSM_Transition : MonoBehaviour
{
    //Value
    private FSM_Controller _owner;

    [SerializeField]
    private FSM_State _nextState;
    public FSM_State NextState => _nextState;
    private List<FSM_Condition> _transitionConditions;

    private void OnValidate()
    {
        if (_nextState == null)
            return;

        name = $"{_nextState.GetType().Name}_Transition";
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
    public void SetOwner(FSM_Controller owner)
    {
        _owner = owner;

        _transitionConditions = transform.GetComponentsInChildren<FSM_Condition>().ToList<FSM_Condition>();
        foreach(FSM_Condition condition in _transitionConditions)
        {
            condition.SetOwner(owner);
        }    
    }
}
